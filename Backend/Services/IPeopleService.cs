using Backend.Controllers;

namespace Backend.Services
{
    public interface IPeopleService
    {
        // toda clase que implemente la interfaz debe implementar los metodos que se declaren
        bool Validate(People people);
    }
}
