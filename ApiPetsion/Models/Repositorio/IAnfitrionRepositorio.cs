using ApiPetsion.DTOs;

namespace ApiPetsion.Models.Repositorio
{
    public interface IAnfitrionRepositorio
    {
        IEnumerable<Anfitrion> ObtenerTodos();
        Anfitrion ObtenerPorId(int id);
        void Agregar(Anfitrion anfitrion);
        void Actualizar(Anfitrion anfitrion);
        void Eliminar(int id);


    }
}
