﻿namespace UTTT.Micro.Libro.Applicaciones
{
    public class LibroMaterialDto
    {
        public Guid? LibreriaMaterialId { get; set; }

        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }

        public Guid? AutorLibro { get; set; }
    }
}
