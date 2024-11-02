using System.Diagnostics.Contracts;

namespace Backend.DTOs
{

    // el dto sirve para mostrar la informacion que realmente queremos de una tabla que quizas tengo 20 atributos
    public class BeerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal Alcohol { get; set; }

    }
}
