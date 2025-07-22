using System.ComponentModel.DataAnnotations;
using System.Data;

namespace UTTT.Micro.Libro.Models
{
    public class LibreriasMateriales
    {
        [Key]
        public Guid? LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
        public int NewData { get; set; }
    }
}
