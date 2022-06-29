using MediatR;
using Microsoft.AspNetCore.Mvc;
using SmartBus.Authentification;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Queries;
using System.Threading.Tasks;

namespace smart_bus_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EventualidadController : ControllerBase
    {
        private readonly IMediator mediator;
        public EventualidadController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        [Route("{idPasajero}")]
        public async Task<IActionResult> Get(int idPasajero)
        {
            var response = await mediator.Send(new ObtenerEventualidadesQuery(idPasajero));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarEventualidadCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ModificarEventualidadCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new EliminarEventualidadCommand(id));
            return Ok(response);
        }
    }
}
