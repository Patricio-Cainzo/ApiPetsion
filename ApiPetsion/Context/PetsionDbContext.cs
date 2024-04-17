using ApiPetsion.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiPetsion.Context
{
    public class PetsionDbContext:DbContext
    {
        public PetsionDbContext(DbContextOptions<PetsionDbContext> options) : base(options) { }

        public DbSet<Anfitrion> Anfitriones { get; set; }
        public DbSet<UsuarioDueno> Usuarios { get; set; }

    }
}
