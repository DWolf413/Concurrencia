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

        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }
    }
}