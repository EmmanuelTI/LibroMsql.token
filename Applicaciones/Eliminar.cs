using MediatR;
using Microsoft.EntityFrameworkCore;
using UTTT.Micro.Libro.Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

public class Eliminar
{
    public class Ejecuta : IRequest<Unit>
    {
        public Guid LibreriaMaterialId { get; set; }
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
            var libro = await _contexto.LibreriasMateriales
                .FirstOrDefaultAsync(x => x.LibreriaMaterialId == request.LibreriaMaterialId, cancellationToken);

            if (libro == null)
            {
                throw new Exception("No se encontró el libro con ese ID");
            }

            _contexto.LibreriasMateriales.Remove(libro);

            var resultado = await _contexto.SaveChangesAsync(cancellationToken);

            if (resultado > 0)
                return Unit.Value;

            throw new Exception("No se pudo eliminar el libro");
        }
    }
}
