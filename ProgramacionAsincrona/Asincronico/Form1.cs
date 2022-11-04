using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Asincronico
{
    public partial class Form1 : Form
    {
        private string apiURL;
        private HttpClient httpClient;
        private CancellationTokenSource cancellationTokenSource;
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
            /*
            cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
            loadingGIF.Visible = true;
            pgProcesamiento.Visible = true;
            var reportarProgreso = new Progress<int>(ResportarProgresoTareas);
            //await Task.Delay(TimeSpan.FromSeconds(5));
            // await Esperar();
            //var nombre = txtInput.Text;

            //var tarjetas =  await ObtenerTarjetasCredito(20, cancellationTokenSource.Token);
            var stopwatch = new Stopwatch();
            stopwatch.Start();


            try
            {
                //var saludo = await ObtenerSaludo(nombre);
                //MessageBox.Show(saludo);
                var tarjetas = await ObtenerTarjetasCredito(20, cancellationTokenSource.Token);
                await ProcesarTarjetas(tarjetas, reportarProgreso, cancellationTokenSource.Token);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (TaskCanceledException ex) 
            {
                MessageBox.Show("La operacion ha sido cancelada");
            }


            MessageBox.Show($"Operació finalizada en {stopwatch.ElapsedMilliseconds / 1000.0} segundos");
            loadingGIF.Visible = false;
            pgProcesamiento.Visible = false;
            pgProcesamiento.Value = 0;
            */

            //Sincronizacion
            /*
            loadingGIF.Visible = true;
            Console.WriteLine($"Hilo antes del await: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(500);
            Console.WriteLine($"Hilo despuess del await: {Thread.CurrentThread.ManagedThreadId}");

            await ObtenerSaludos2("David");
            loadingGIF.Visible = false;
            

            CheckForIllegalCrossThreadCalls = true;
            loadingGIF.Visible = true;
            btnCancelar.Text = "antes";
            Console.WriteLine($"Hilo antes del await: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: false);
            Console.WriteLine($"Hilo despuess del await: {Thread.CurrentThread.ManagedThreadId}");
            btnCancelar.Text = "despues";
            loadingGIF.Visible = false;
            */

            //PAtron Reintento
            //loadingGIF.Visible = true;
            //var reintentos = 3;
            //var tiempoEspera = 500;

            /*for (int i = 0; i < reintentos; i++) 
            {
                try
                {
                    //Operaciion
                    break;
                }
                catch (Exception)
                {
                    //loguear exepcion
                    await Task.Delay(tiempoEspera);
                }
            }*/

            /*await Reintentar(async () => {
                using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos2/David")) 
                { 
                    respuesta.EnsureSuccessStatusCode();
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    Console.WriteLine(contenido);
                }
            });

            //await Reintentar(ProcesarSaludo);

            try
            {
                var contenido = await Reintentar(async () =>
                {
                    using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos/David"))
                    {
                        respuesta.EnsureSuccessStatusCode();
                        return await respuesta.Content.ReadAsStringAsync();

                    }
                });

                Console.WriteLine(contenido);
            }
            catch (Exception ex )
            {

                Console.WriteLine("Exepcion atrapada");
            }
            
            loadingGIF.Visible = false;*/

            //Patron Una Sola Trea
            /*
            loadingGIF.Visible = true;

            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            var nombres = new string[] { "David", "Sofia", "Esteban", "Carson" };
            //var tareasHTTP = nombres.Select(x => ObtenerSaludos2(x, token));
            //var tarea = await Task.WhenAny(tareasHTTP);
            //var contenido = await tarea;
            //Console.WriteLine(contenido.ToUpper());
            //cancellationTokenSource.Cancel();

            //var tareasHTTP = nombres.Select(x =>
            //{
            //    Func<CancellationToken, Task<string>> fuction = (ct) => ObtenerSaludos2(x, ct);
            //    return fuction;
            //});

            //var contenido = await EjecutarUno(tareasHTTP);
            //Console.WriteLine(contenido.ToUpper());

            var contenido = await EjecutarUno(
                (ct) => ObtenerSaludos2("Sofia", ct),
                (ct) => ObtenerAdios("Sofia", ct));
            Console.WriteLine(contenido.ToUpper());

            loadingGIF.Visible = false;
            */

            loadingGIF.Visible = true;
            var tarea = EvaluarValor(txtInput.Text);
            Console.WriteLine("Inicio");
            Console.WriteLine($"Is Completed: {tarea.IsCompleted}");
            Console.WriteLine($"Is Canceled: {tarea.IsCanceled}");
            Console.WriteLine($"Is Faulted: {tarea.IsFaulted}");

            try
            {
                await tarea;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Exception: {ex.Message}");

            }
            Console.WriteLine("Fin");
            Console.WriteLine("");



            loadingGIF.Visible = false;



        }

        private Task EvaluarValor(string valor)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (valor == "1") tcs.SetResult(null);
            else if (valor == "2") tcs.SetCanceled();
            else tcs.SetException(new ApplicationException($"Valor invalido: {valor}"));

            return tcs.Task;
        }

        private async Task<string> ObtenerAdios(string nombre, CancellationToken cancellationToken)
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos/adios/{nombre}", cancellationToken))
            {
                var saludos = await respuesta.Content.ReadAsStringAsync();
                Console.WriteLine(saludos);
                return saludos;
            }
        }


        private async Task<string> ObtenerSaludos2(string nombre, CancellationToken cancellationToken)
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos/delay/{nombre}", cancellationToken))
            {
                var saludos = await respuesta.Content.ReadAsStringAsync();
                Console.WriteLine(saludos);
                return saludos;
            }
        }

        private async Task ProcesarSaludo() 
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos/David"))
            {
                respuesta.EnsureSuccessStatusCode();
                var contenido = await respuesta.Content.ReadAsStringAsync();
                Console.WriteLine(contenido);
            }
        }

        private async Task Reintentar(Func<Task> f, int reintentos = 3, int tiempoEspera = 500) 
        {
            for (int i = 0; i < reintentos; i++)
            {
                try
                {
                    await f();
                    break;
                }
                catch (Exception ex)
                {
                    //loguear exepcion
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempoEspera);
                }
            }
        }

        private async Task<T> Reintentar<T>(Func<Task<T>> f, int reintentos = 3, int tiempoEspera = 500)
        {
            for (int i = 0; i < reintentos -1; i++)
            {
                try
                {
                    return await f();
                }
                catch (Exception ex)
                {
                    //loguear exepcion
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempoEspera);
                }
            }

            return await f();
        }

        private async Task<T> EjecutarUno<T>(IEnumerable<Func<CancellationToken, Task<T>>> funciones) 
        { 
            var cts = new CancellationTokenSource();
            var tareas = funciones.Select(f => f(cts.Token));
            var tarea = await Task.WhenAny(tareas);
            cts.Cancel();
            return await tarea;
        }

        private async Task<T> EjecutarUno<T>(params Func<CancellationToken, Task<T>>[] funciones)
        {
            var cts = new CancellationTokenSource();
            var tareas = funciones.Select(f => f(cts.Token));
            var tarea = await Task.WhenAny(tareas);
            cts.Cancel();
            return await tarea;
        }

        private async Task<string> ObtenerSaludos2(string nombre) 
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos/delay/{nombre}")) 
            { 
                var saludos = await respuesta.Content.ReadAsStringAsync();
                return saludos;
            }
        }

        private void ResportarProgresoTareas(int porcentaje) 
        { 
            pgProcesamiento.Value = porcentaje;
        }

        private Task ProcesarTarjetasMock(List<string> tarjetas, IProgress<int> progress = null, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        private async Task ProcesarTarjetas(List<string> tarjetas, IProgress<int> progress = null, CancellationToken cancellationToken = default) 
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
                    var tareaInterna = await httpClient.PostAsync($"{apiURL}/tarjetas", content, cancellationToken);

                    
                    /*if (progress != null) 
                    {
                        indice++;
                        var porcentaje = (double)indice / tarjetas.Count;
                        porcentaje = porcentaje * 100;
                        var porcentajeInt = (int)Math.Round(porcentaje,0);
                        progress.Report(porcentajeInt);

                    }*/

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
            //var respuestas = await Task.WhenAll(tareas);
            var respuestasTareas = Task.WhenAll(tareas);

            if (progress != null) 
            {
                while (await Task.WhenAny(respuestasTareas, Task.Delay(1000)) != respuestasTareas) 
                {
                    var tareasCompletadas = tareas.Where(x => x.IsCompleted).Count();
                    var porcentaje = (double)tareasCompletadas / tarjetas.Count;
                    porcentaje = porcentaje * 100;
                    var porcentajeInt = (int)Math.Round(porcentaje, 0);
                    progress.Report(porcentajeInt);
                }
            }

            var respuestas = await respuestasTareas;
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
        private Task<List<string>> ObtenerTarjetasCreditoMock(int cantidadTarjetas, CancellationToken cancellationToken = default)
        {
            var tarjetas = new List<string>();
            tarjetas.Add("000000000001");

            return Task.FromResult(tarjetas);
        }

        private Task ObtenerTareaConError() 
        {
            return Task.FromException(new ApplicationException());
        }

        private Task ObtenerTareaCancelada()
        {
            cancellationTokenSource = new CancellationTokenSource();
            return Task.FromCanceled(cancellationTokenSource.Token);
        }
        private async Task<List<string>> ObtenerTarjetasCredito(int cantidadTarjetas, CancellationToken cancellationToken = default)
        {
            return await Task.Run( () =>
            {
                var tarjetas = new List<string>();
                for (int i = 0; i < cantidadTarjetas; i++)
                {
                    //await Task.Delay(1000);
                    tarjetas.Add(i.ToString().PadLeft(16, '0'));

                    //Console.WriteLine($"Han sido generadas {tarjetas.Count} tarjetas");

                    if (cancellationToken.IsCancellationRequested) 
                    {
                        throw new TaskCanceledException();
                    }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}