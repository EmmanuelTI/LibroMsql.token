using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UTTT.Micro.Libro.Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Editar
{
    public class Ejecuta : IRequest<Unit>
    {
        public Guid LibreriaMaterialId { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public Guid? AutorLibro { get; set; }
    }

    public class EjecutaValidacion : AbstractValidator<Ejecuta>
    {
        public EjecutaValidacion()
        {
            RuleFor(x => x.LibreriaMaterialId).NotEmpty();
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.FechaPublicacion).NotEmpty();
            RuleFor(x => x.AutorLibro).NotEmpty();
        }
    }

    public class Manejador : IRequestHandler<Ejecuta, Unit>
    {
        private readonly ContextoLibreria _contexto;

        public Manejador(ContextoLibreria contexto)
        {
            _contexto = contexto;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var libro = await _contexto.LibreriasMaterial
                .FirstOrDefaultAsync(x => x.LibreriaMaterialId == request.LibreriaMaterialId, cancellationToken);

            if (libro == null)
            {
                throw new Exception("El libro no fue encontrado");
            }

            libro.Titulo = request.Titulo ?? libro.Titulo;
            libro.FechaPublicacion = request.FechaPublicacion ?? libro.FechaPublicacion;
            libro.AutorLibro = request.AutorLibro ?? libro.AutorLibro;

            var resultado = await _contexto.SaveChangesAsync(cancellationToken);

            if (resultado > 0)
                return Unit.Value;

            throw new Exception("No se guardaron los cambios");
        }
    }
}
