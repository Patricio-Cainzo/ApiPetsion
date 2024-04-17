using ApiPetsion.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiPetsion.Models.Repositorio
{
    public class UsuarioDuenoRepositorio:IUsuarioDuenoRepositorio
    {
        private readonly PetsionDbContext _context;

        // Constructor que recibe una instancia de PetsionDbContext mediante inyección de dependencias
        public UsuarioDuenoRepositorio(PetsionDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los Usuarios Duenos
        public IEnumerable<UsuarioDueno> ObtenerTodos()
        {
            // Retorna una lista de todos los Usuario Dueno en la base de datos
            return _context.Usuarios.ToList();
        }

        // Método para obtener un Usuario Dueno por su ID
        public UsuarioDueno ObtenerPorId(int id)
        {
            // Retorna el Usuario Dueno con el ID proporcionado
            return _context.Usuarios.Find(id);
        }

        // Método para agregar un nuevo Usuario Dueno
        public void Agregar(UsuarioDueno usuario)
        {
            // Agrega el nuevo Usuario al contexto y guarda los cambios en la base de datos
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        // Método para actualizar un Usuario existente
        public void Actualizar(UsuarioDueno usuario)
        {
            // Marca el usuario como modificado en el contexto y guarda los cambios en la base de datos
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Método para eliminar un usuario por su ID
        public void Eliminar(int id)
        {
            // Busca el usuario por su ID, lo elimina del contexto y guarda los cambios en la base de datos
            var usuario = _context.Usuarios.Find(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
