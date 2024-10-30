using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        // declaramos la variable privada de tipo interfaz
        private IPeopleService _peopleService;
        
        // constructor de la clase
        public PeopleController([FromKeyedServices("people2Service")]IPeopleService peopleService)
        {
            // recibimos de manera inyectada la interfaz
            _peopleService = peopleService;
        }
    

        [HttpGet("all")]  // entraremos a /people/all para activar el metodo
        // fn del controlador para obtener personas
        public List<People> GetPeople() => Repository.People;


        // filtrado por id unico
        [HttpGet("{id}")] // indica que el primer elemento que se envie por url va a ser el parametro del id. Puede agregarse un segundo elemento "{id}/{some}" y en la declaracion de la fn public People Get(int id, tipo_dato some)
        public ActionResult<People> Get(int id) // action result es un Generic
        {
            var people = Repository.People.FirstOrDefault(p => p.Id == id); // FirsOrDefault devuelve null en caso de no encontrar el objeto
            if (people == null)
            {
                return NotFound(); // retorna un error 404, pero not found retornara el valor correcto para cada caso.
            }
            return Ok(people);// de lo contrario retorna el recurso encontrado (200)

        }


        // mas de una coincidencia
        [HttpGet("/search/{search}")]
        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList(); // usamos linq para recorrer la fuente de datos, y la convertimos a lista.


        // usamos la interfaz IActionResault para los metodos que no devuelven paramentros.
        // Put, Post, Delete
        [HttpPost]
        public IActionResult Add(People people) 
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest(); 
            }

            Repository.People.Add(people);
            return NoContent();// no retornamos nada ya que post es para insertar info. Devuelve un 204 No content

        }

    }


    // clase persona
    public class People()
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }


    // simulamos fuente de datos
    public class Repository()
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1,
                Name = "Pepe",
                BirthDate = new DateTime(1990, 12, 20)
            },
            new People()
            {
                Id = 2,
                Name = "Pepa",
                BirthDate = new DateTime(1990, 12, 21)
            },
            new People()
            {
                Id = 3,
                Name = "Pipa",
                BirthDate = new DateTime(1990, 12, 22)
            }
        };
    }
}
