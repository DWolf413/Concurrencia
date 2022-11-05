using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo2
{
    public class N_ConfigureAwait
    {
        public async Task btnIniciar_Click(PictureBox loadingGIF, Button btnCancelar)
        {
            loadingGIF.Visible = true;

            btnCancelar.Text = "antes";

            // error: Llamado ilegal entre hilos por el acceso a btnCancelar más abajo
            //await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: false);

            // Las siguientes dos líneas son equivalentes
            await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: true);
            await Task.Delay(1000);

            btnCancelar.Text = "después";

            loadingGIF.Visible = false;
        }

    }
}
