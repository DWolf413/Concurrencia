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
            await Esperar();
            var nombre = txtInput.Text;
            try
            {
                var saludo = await ObtenerSaludo(nombre);
                MessageBox.Show(saludo);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            loadingGIF.Visible = false;

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