using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("Sync")]
        public IActionResult GetSync() 
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            // simulamos conexion a la bd
            Thread.Sleep(1000);
            Console.WriteLine("Conexion a bases de dato terminada");
            //return Ok();

            // simulamos envio de correo
            Thread.Sleep(1000);
            Console.WriteLine("Correo enviado correctamente");
            //return Ok();

            Console.WriteLine("Todo terminado");

            sw.Stop();

            return Ok(sw.Elapsed);
        }

        [HttpGet("Async")]
        public async Task<IActionResult> GetAsync() 
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a bases de dato terminada");
                return 1;
            });

            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio de mail realizado");
                return 2;
            });

            task1.Start();
            task2.Start();


            Console.WriteLine("Hago otra cosa");

            var result1 = await task1;
            var result2 = await task2;

            Console.WriteLine("Todo ha terminado");

            sw.Stop();

            return Ok(result1 + " " + result2 + " " + sw.Elapsed);
        }


    }
}
