namespace Asincronico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            MessageBox.Show("No pasaron los 5 segundos");
            loadingGIF.Visible = false;

        }

        private async Task Esperar() 
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}