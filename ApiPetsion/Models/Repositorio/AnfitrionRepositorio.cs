using ApiPetsion.Context;
using ApiPetsion.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ApiPetsion.Models.Repositorio
{
    public class AnfitrionRepositorio: IAnfitrionRepositorio
    {
        private readonly PetsionDbContext _context;

        // Constructor que recibe una instancia de PetsionDbContext mediante inyección de dependencias
        public AnfitrionRepositorio(PetsionDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los Anfitriones 
        public IEnumerable<Anfitrion> ObtenerTodos()
        {
            // Retorna una lista de todos los Anfitrion en la base de datos
            return _context.Anfitriones.ToList();
        }

        // Método para obtener un Anfitriones  por su ID
        public Anfitrion ObtenerPorId(int id)
        {
            // Retorna el Anfitriones  con el ID proporcionado
            return _context.Anfitriones.Find(id);
        }

        // Método para agregar un nuevo Anfitrion
        // 
        public void Agregar(Anfitrion anfitrion)
        {
            try
            {
                // Agrega el nuevo Anfitrion al contexto y guarda los cambios en la base de datos
                _context.Anfitriones.Add(anfitrion);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Captura la excepción y muestra los detalles
                Console.WriteLine(ex.ToString());
                throw; // Lanza la excepción para que sea manejada en un nivel superior
            }
        }

        // Método para actualizar un Anfitrion existente
        public void Actualizar(Anfitrion anfitrion)
        {
            // Marca el Anfitrion como modificado en el contexto y guarda los cambios en la base de datos
            _context.Entry(anfitrion).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Método para eliminar un Anfitrion por su ID
        public void Eliminar(int id)
        {
            // Busca el anfitrion por su ID, lo elimina del contexto y guarda los cambios en la base de datos
            var anfitrion = _context.Anfitriones.Find(id);
            _context.Anfitriones.Remove(anfitrion);
            _context.SaveChanges();
        }
        

    }
}
