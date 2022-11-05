using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo3
{
    public class A_Repaso_IEnumerable
    {
        public void btnIniciar_Click()
        {
            foreach (var nombre in GenerarNombres())
            {
                Console.WriteLine(nombre);
            }
        }

        private IEnumerable<string> GenerarNombres()
        {
            yield return "Felipe";
            yield return "Claudia";
        }

    }
}
