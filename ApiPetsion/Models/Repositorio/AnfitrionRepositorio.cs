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
        public IEnumerable<Anfitrion> BuscarAnfitriones(BusquedaAnfitrionDTO busquedaAnfitrion)
        {
            // Construye la consulta inicial
            var query = _context.Anfitriones.AsQueryable();

            // Aplica filtros según los atributos proporcionados en el DTO de búsqueda
            if (!string.IsNullOrEmpty(busquedaAnfitrion.TipoVivienda))
                query = query.Where(a => a.TipoVivienda == busquedaAnfitrion.TipoVivienda);

            if (busquedaAnfitrion.Patio)
                query = query.Where(a => a.Patio == true);

            if (busquedaAnfitrion.AdmiteGato)
                query = query.Where(a => a.AdmiteGato == true);

            if (busquedaAnfitrion.AdmitePerroGrande)
                query = query.Where(a => a.AdmitePerroGrande == true);

            if (busquedaAnfitrion.AdmitePerroMediano)
                query = query.Where(a => a.AdmitePerroMediano == true);

            if (busquedaAnfitrion.AdmitePerroPequeno)
                query = query.Where(a => a.AdmitePerroPequeno == true);

            if (busquedaAnfitrion.PaseoMascota)
                query = query.Where(a => a.PaseoMascota == true);

            if (busquedaAnfitrion.OfreceAlojamiento)
                query = query.Where(a => a.OfreceAlojamiento == true);

            if (busquedaAnfitrion.GuarderiaDiurna)
                query = query.Where(a => a.GuarderiaDiurna == true);

            if (busquedaAnfitrion.DisponibleLunes)
                query = query.Where(a => a.DisponibleLunes == true);

            if (busquedaAnfitrion.DisponibleMartes)
                query = query.Where(a => a.DisponibleMartes == true);

            if (busquedaAnfitrion.DisponibleMiercoles)
                query = query.Where(a => a.DisponibleMiercoles == true);

            if (busquedaAnfitrion.DisponibleJueves)
                query = query.Where(a => a.DisponibleJueves == true);

            if (busquedaAnfitrion.DisponibleViernes)
                query = query.Where(a => a.DisponibleViernes == true);

            if (busquedaAnfitrion.DisponibleSabado)
                query = query.Where(a => a.DisponibleSabado == true);

            if (busquedaAnfitrion.DisponibleDomingo)
                query = query.Where(a => a.DisponibleDomingo == true);

            // Agrega la condición para la cantidad de mascotas
            if (busquedaAnfitrion.CantidadMascotaAdmite > 0)
                query = query.Where(a => a.CantidadmascotaAdmite >= busquedaAnfitrion.CantidadMascotaAdmite);

            // Continúa con los demás filtros...

            // Ejecuta la consulta y devuelve los resultados
            var anfitriones = query.ToList();

            return anfitriones;
        }

    }
}
