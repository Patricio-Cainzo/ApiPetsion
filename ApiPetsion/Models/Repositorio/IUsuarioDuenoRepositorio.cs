namespace ApiPetsion.Models.Repositorio
{
    public interface IUsuarioDuenoRepositorio
    {
        IEnumerable<UsuarioDueno> ObtenerTodos();
        UsuarioDueno ObtenerPorId(int id);
        void Agregar(UsuarioDueno gasto);
        void Actualizar(UsuarioDueno gasto);
        void Eliminar(int id);
    }
}
