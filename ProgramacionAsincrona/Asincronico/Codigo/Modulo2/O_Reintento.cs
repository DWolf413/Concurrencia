using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asincronico.Codigo.Modulo2
{
    public class O_Reintento
    {
        private readonly string apiURL;
        private readonly HttpClient httpClient;

        public O_Reintento(string apiURL)
        {
            this.apiURL = apiURL;
            httpClient = new HttpClient();
        }

        public async Task btnIniciar_Click(PictureBox loadingGIF)
        {
            loadingGIF.Visible = true;

            //var reintentos = 3;
            //var tiempoEspera = 500;
            //for (int i = 0; i < reintentos; i++)
            //{
            //    try
            //    {
            //        // operación
            //        break;
            //    }
            //    catch(Exception ex)
            //    {
            //        // loguear la excepción
            //        await Task.Delay(tiempoEspera);
            //    }
            //}

            await Reintentar(ProcesarSaludo);

            try
            {
                var contenido = await Reintentar(async () =>
                {
                    using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos2/Felipe"))
                    {
                        respuesta.EnsureSuccessStatusCode();
                        return await respuesta.Content.ReadAsStringAsync();
                    }
                });

                Console.WriteLine(contenido);
            }
            catch (Exception ex)
            {
                Console.WriteLine("excepción atrapada");
            }


            loadingGIF.Visible = false;
        }

        private async Task ProcesarSaludo()
        {
            using (var respuesta = await httpClient.GetAsync($"{apiURL}/saludos2/Felipe"))
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
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempoEspera);
                }
            }
        }

        private async Task<T> Reintentar<T>(Func<Task<T>> f, int reintentos = 3, int tiempoEspera = 500)
        {
            for (int i = 0; i < reintentos - 1; i++)
            {
                try
                {
                    return await f();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempoEspera);
                }
            }

            return await f();
        }
    }
}
