using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo3
{
    public class B_Stream_Asincrono
    {
        public async Task btnIniciar_Click(PictureBox loadingGIF)
        {
            loadingGIF.Visible = true;

            await foreach (var nombre in GenerarNombres())
            {
                Console.WriteLine(nombre);
            }

            loadingGIF.Visible = false;
        }

        private async IAsyncEnumerable<string> GenerarNombres()
        {
            yield return "Felipe";
            await Task.Delay(2000);
            yield return "Claudia";
        }
    }
}
