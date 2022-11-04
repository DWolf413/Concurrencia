using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Asincronico
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;
        public Form1()
        {
            InitializeComponent();
            apiURL = "http://localhost:5029";
            httpClient = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            //Version Sincrona
            //Thread.Sleep(5000);

            //Version Asincrona
            loadingGIF.Visible = true;
            //await Task.Delay(TimeSpan.FromSeconds(5));
            // await Esperar();
            //var nombre = txtInput.Text;

            var tarjetas =  await ObtenerTarjetasCredito(25000);
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            try
            {
                //var saludo = await ObtenerSaludo(nombre);
                //MessageBox.Show(saludo);
                await ProcesarTarjetas(tarjetas);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }


            MessageBox.Show($"Operació finalizada en {stopwatch.ElapsedMilliseconds / 1000.0} segundos");
            loadingGIF.Visible = false;

        }

        private async Task ProcesarTarjetas(List<string> tarjetas) 
        {
            using var semaforo = new SemaphoreSlim(4000);
            var tareas = new List<Task<HttpResponseMessage>>();

            tareas = tarjetas.Select(async tarjeta =>
            {
                var json = JsonConvert.SerializeObject(tarjeta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await semaforo.WaitAsync();
                try 
                {
                    return await httpClient.PostAsync($"{apiURL}/tarjetas", content);
                }
                finally 
                { 
                    semaforo.Release();
                }
                
            }).ToList();

            
            //Creacion de un hilo para desbloquear UI
            /*
            await Task.Run(() =>
            {
                foreach (var tarjeta in tarjetas)
                {
                    var json = JsonConvert.SerializeObject(tarjeta);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var respuestasTask = httpClient.PostAsync($"{apiURL}/tarjetas", content);
                    tareas.Add(respuestasTask);
                }
            });*/

            //await Task.WhenAll(tareas);
            var respuestas = await Task.WhenAll(tareas);
            var tarjetasRechazadas = new List<string>();

            foreach (var respuesta in respuestas) 
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                var respuestaTarjeta = JsonConvert.DeserializeObject<RespuestaTarjeta>(contenido);

                if (!respuestaTarjeta.Aprobada) 
                {
                    tarjetasRechazadas.Add(respuestaTarjeta.Tarjeta);
                }

            }

            foreach (var tarjeta in tarjetasRechazadas) 
            {
                Console.WriteLine(tarjeta);
            }
           
        }

        private async Task<List<string>> ObtenerTarjetasCredito(int cantidadTarjetas)
        {
            return await Task.Run(() =>
            {
                var tarjetas = new List<string>();
                for (int i = 0; i < cantidadTarjetas; i++)
                {
                    tarjetas.Add(i.ToString().PadLeft(16, '0'));
                }

                return tarjetas;
            });

           
        }

        private async Task Esperar() 
        {
            await Task.Delay(TimeSpan.FromSeconds(0));
        }

        private async Task<string> ObtenerSaludo(string nombre) 
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos2/{nombre}")) 
            { 
                respuesta.EnsureSuccessStatusCode();
                var saludos = await respuesta.Content.ReadAsStringAsync();
                return saludos;
            }
        }


    }
}