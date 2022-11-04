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
            pgProcesamiento.Visible = true;
            var reportarProgreso = new Progress<int>(ResportarProgresoTareas);
            //await Task.Delay(TimeSpan.FromSeconds(5));
            // await Esperar();
            //var nombre = txtInput.Text;

            var tarjetas =  await ObtenerTarjetasCredito(20);
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            try
            {
                //var saludo = await ObtenerSaludo(nombre);
                //MessageBox.Show(saludo);
                await ProcesarTarjetas(tarjetas, reportarProgreso);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }


            MessageBox.Show($"Operació finalizada en {stopwatch.ElapsedMilliseconds / 1000.0} segundos");
            loadingGIF.Visible = false;
            pgProcesamiento.Visible = false;

        }

        private void ResportarProgresoTareas(int porcentaje) 
        { 
            pgProcesamiento.Value = porcentaje;
        }

        private async Task ProcesarTarjetas(List<string> tarjetas, IProgress<int> progress = null) 
        {
            using var semaforo = new SemaphoreSlim(2);
            var tareas = new List<Task<HttpResponseMessage>>();
            var indice = 0;

            tareas = tarjetas.Select(async tarjeta =>
            {
                var json = JsonConvert.SerializeObject(tarjeta);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await semaforo.WaitAsync();
                try 
                {
                    var tareaInterna = await httpClient.PostAsync($"{apiURL}/tarjetas", content);

                    if (progress != null) 
                    {
                        indice++;
                        var porcentaje = (double)indice / tarjetas.Count;
                        porcentaje = porcentaje * 100;
                        var porcentajeInt = (int)Math.Round(porcentaje,0);
                        progress.Report(porcentajeInt);

                    }

                    return tareaInterna;
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