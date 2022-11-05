using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo4
{
    public class B_StartNew
    {
        public async Task btnIniciar_Click(PictureBox loadingGIF)
        {
            loadingGIF.Visible = true;

            var resultadoStartNew = await Task.Factory.StartNew(async () =>
            {
                await Task.Delay(1000);
                return 7;
            }).Unwrap();

            var resultadoRun = await Task.Run(async () =>
            {
                await Task.Delay(1000);
                return 7;
            });

            Console.WriteLine($"Resultado StartNew: {resultadoStartNew}");
            Console.WriteLine("----");
            Console.WriteLine($"Resultado Task.run: {resultadoRun}");


            loadingGIF.Visible = false;
        }
    }
}
