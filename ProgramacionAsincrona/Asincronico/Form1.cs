using Asincronico.Codigo.Modulo2;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
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

            loadingGIF.Visible = true;

            // Video: UI Que no se Congela
            //new A_UI_Que_No_Se_Congela().VersionSincrona(loadingGIF);
            //await new A_UI_Que_No_Se_Congela().VersionAsincrona(loadingGIF);

            //Videos: Task y Task Que Retorna Un Valor
            //await new B_Task_Y_TaskDeT(apiURL).btnIniciar_Click(loadingGIF, txtInput);

            // Videos: Tasks Que no Son Exitosas
            //await new C_Task_No_Exitosa(apiURL).btnIniciar_Click(loadingGIF, txtInput);

            // Videos: Ejecutando Múltiples Tareas - Task.WhenAll
            //await new D_Task_WhenAll(apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Creando Nuevas Tareas con Task.Run
            //await new E_Task_Run(apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Limitando las Tareas con un Semáforo - SemaphoreSlim
            //await new F_Semaforo(apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Flujo de Tareas
            //await new G_Flujo_de_Tareas(apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Reportando Progreso con IProgress
            //await new H_Reportando_Progreso(pgProcesamiento, apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Reportando Progreso por Intervalos con Task.WhenAny
            //await new I_Reportando_Progreso_Tiempo(pgProcesamiento, apiURL).btnIniciar_Click(loadingGIF);

            // Videos: Cancelando Tareas - Tokens de Cancelación
            //cancellationTokenSource = new CancellationTokenSource();
            //await new J_Cancelando_Tareas(pgProcesamiento, apiURL, cancellationTokenSource).btnIniciar_Click(loadingGIF);

            // Videos: Cancelando Bucles
            //cancellationTokenSource = new CancellationTokenSource();
            //await new K_Cancelando_Bucles(pgProcesamiento, apiURL, cancellationTokenSource).btnIniciar_Click(loadingGIF);

            // Videos: Cancelando Tareas por Tiempo -Timeout
            //cancellationTokenSource = new CancellationTokenSource();
            //cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            //await new L_Cancelando_Timeout(pgProcesamiento, apiURL, cancellationTokenSource).btnIniciar_Click(loadingGIF);

            // Videos: Creando Tareas ya Terminadas - Task.FromResult y Amigos
            //var creando_Tareas_Terminadas = new M_Creando_Tareas_Terminadas();
            //var tarjetas = await creando_Tareas_Terminadas.ObtenerTarjetasDeCreditoMock(1);
            //await creando_Tareas_Terminadas.ProcesarTarjetasMock(tarjetas);
            //await creando_Tareas_Terminadas.ObtenerTareaCancelada();
            //await creando_Tareas_Terminadas.ObtenerTareaConError();  // Esta lanza un error al hacerle await

            // Videos: Entendiendo ConfigureAwait -Ignorando el Contexto de Sincronización
            //CheckForIllegalCrossThreadCalls = true; // Esto solo es necesario en apps de WinForms
            //await new N_ConfigureAwait().btnIniciar_Click(loadingGIF, btnCancelar);

            // Videos: Patrón de Reintento
            //await new O_Reintento(apiURL).btnIniciar_Click(loadingGIF);


            // Videos: Patrón Solo Una Tarea
            //cancellationTokenSource = new CancellationTokenSource();
            //await new P_Solo_Uno(apiURL, cancellationTokenSource).btnIniciar_Click(loadingGIF);

            // Videos: Controlando el Resultado de la Tarea - TaskCompletionSource
            //await new Q_TaskCompletionSource_Ejemplo().btnIniciar_Click(loadingGIF, txtInput);

            // Videos: Cancelando Tareas no Cancelables con TaskCompletionSource
            //cancellationTokenSource = new CancellationTokenSource();
            //await new R_Cancelando_Tareas_No_Cancelables(cancellationTokenSource).btnIniciar_Click(loadingGIF);

            //Modulo 3 

            // Video: Repasando IEnumerable y yield
            //new A_Repaso_IEnumerable().btnIniciar_Click();

            // Video: Streams Asíncronos
            //await new B_Stream_Asincrono().btnIniciar_Click(loadingGIF);

            // Video: Cancelando Streams Asíncronos
            //cancellationTokenSource = new CancellationTokenSource();
            //await new C_Cancelando_Stream_Asincrono(cancellationTokenSource).btnIniciar_Click(loadingGIF);
            //cancellationTokenSource = null;

            //Modulo 4
            // Video: Síncrono dentro de Asíncrono - Bloqueo Mutuo
            //await new A_Sincrono_Dentro_De_Asincrono().btnIniciar_Click(loadingGIF);

            // Video: Evitar Task.Factory.StartNew
            //await new B_StartNew().btnIniciar_Click(loadingGIF);

            // Video: Async void [ver SaludosController en el proyecto de ASP.NET Core]

            //Modulo 5

            // Video: Con Task.WhenAll Ejecutamos Tareas Simultáneas
            //await new A_TaskWhenAll().btnIniciar_Click();

            // Video: Entendiendo Parallel.Fors
            //new B_Intro_Parallel_For().btnIniciar_Click();

            // Video: Ejemplo de Parallel.For - Velocidad
            //await new C_Parallel_For_Matrices().btnIniciar_Click();

            // Video: Iterando Colecciones en Paralelo con Parallel.ForEach
            //new D_Parallel_ForEach().btnIniciar_Click();

            // Video: Parallel.Invoke - Distintos Métodos en Paralelo
            //new E_Parallel_Invoke().btnIniciar_Click();

            // Video: Cancelando Tareas en Paralelo y Máximo Grado de Paralelismo
            //cancellationTokenSource = new ancellationTokenSource();
            //await new F_Maximo_Grado_Paralelismo(cancellationTokenSource).btnIniciar_Click();
            //cancellationTokenSource = null;

            // Video: Interlocked - Operaciones Simples Atómicas
            //new G_Ejemplo_Interlocked().btnIniciar_Click();

            // Video: Locks - Sincronizando Hilos
            //new H_Ejemplo_Lock().btnIniciar_Click();

            // Video: Introducción a PLINQ
            //cancellationTokenSource = new CancellationTokenSource();
            //new I_Intro_LINQ(cancellationTokenSource).btnIniciar_Click();
            //cancellationTokenSource = null;

            // Video: PLINQ - Operaciones de Agregado
            //new J_Aggregate_LINQ().btnIniciar_Click();

            // Video: PLINQ - ForAll - Procesando Resultados de Inmediato
            //new K_LINQ_ForAll().btnIniciar_Click();


        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}