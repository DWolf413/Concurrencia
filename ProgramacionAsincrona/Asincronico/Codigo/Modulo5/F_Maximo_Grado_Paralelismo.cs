using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo5
{
    public class F_Maximo_Grado_Paralelismo
    {
        private CancellationTokenSource cancellationTokenSource;

        public F_Maximo_Grado_Paralelismo(CancellationTokenSource cancellationTokenSource)
        {
            this.cancellationTokenSource = cancellationTokenSource;
        }

        public async Task btnIniciar_Click()
        {
            Console.WriteLine("inicio");

            for (int i = 1; i <= 13; i++)
            {
                await RealizarPruebaMatrices(i);
            }

            Console.WriteLine("fin");
        }

        private async Task RealizarPruebaMatrices(int maximoGradoParalelismo)
        {
            int colCount = 2508;
            int rowCount = 1300;
            int colCount2 = 1850;
            double[,] m1 = Matrices.InicializarMatriz(rowCount, colCount);
            double[,] m2 = Matrices.InicializarMatriz(colCount, colCount2);
            double[,] result = new double[rowCount, colCount2];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                await Task.Run(() => {
                    Matrices.MultiplicarMatricesParalelo(m1, m2, result,
                        cancellationTokenSource.Token, maximoGradoParalelismo);
                });

                Console.WriteLine($"Maximo grado: {maximoGradoParalelismo}; tiempo: {stopwatch.ElapsedMilliseconds / 1000.0}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operación Cancelada");
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }

        }
    }
}
