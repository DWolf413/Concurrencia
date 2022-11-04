using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("saludos")]
    [ApiController]
    public class SaludosController : ControllerBase
    {
        [HttpGet("{nombre}")]
        public ActionResult<string> ObtenerSaludo(string nombre) 
        {
            return $"Hola, {nombre}!";
        }
        
        [HttpGet("delay/{nombre}")]
        public async Task<ActionResult<string>> ObtenerSaludoConDelay(string nombre) 
        {
            //Console.WriteLine($"Hilo antes del await: {Thread.CurrentThread.ManagedThreadId}");
            //await Task.Delay(500);
            //Console.WriteLine($"Hilo despuess del await: {Thread.CurrentThread.ManagedThreadId}");

            var esperar = RandomGen.NextDouble() * 10 + 1;
            await Task.Delay((int)esperar * 1000);
            return $"Hola, {nombre}!";
        }

        [HttpGet("adios/{nombre}")]
        public async Task<ActionResult<string>> ObtenerAdiosConDelay(string nombre)
        {
            //Console.WriteLine($"Hilo antes del await: {Thread.CurrentThread.ManagedThreadId}");
            //await Task.Delay(500);
            //Console.WriteLine($"Hilo despuess del await: {Thread.CurrentThread.ManagedThreadId}");

            var esperar = RandomGen.NextDouble() * 10 + 1;
            //await Task.Delay((int)esperar * 1000);
            OperacionVoidAsync();
            return $"Bye, {nombre}!";
        }

        //Anti-Patron async void
        private async void OperacionVoidAsync()
        {
            await Task.Delay(1);
            throw new ApplicationException();
        }
    }
}
