using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uttt.Micro.Libro.Aplicacion;
using UTTT.Micro.Libro.Applicaciones;

namespace UTTT.Micro.Libro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;


        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroMaterialDto>>> GetLibros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LibroMaterialDto>> GetLibroUnico(Guid id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibroUnico
            {
                LibroId = id
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, [FromBody] Editar.Ejecuta data)
        {
            if (id != data.LibreriaMaterialId)
            {
                return BadRequest("El ID en la URL no coincide con el ID del libro.");
            }

            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await _mediator.Send(new Eliminar.Ejecuta { LibreriaMaterialId = id });
        }




    }
}
