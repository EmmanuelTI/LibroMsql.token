using Microsoft.EntityFrameworkCore;
using UTTT.Micro.Libro.Models;

namespace UTTT.Micro.Libro.Persistencia
{
    public class ContextoLibreria : DbContext
    {
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options) : base(options)
        {

        }

        public DbSet<LibreriasMateriales> LibreriasMateriales { get ; set; }

    }
}
