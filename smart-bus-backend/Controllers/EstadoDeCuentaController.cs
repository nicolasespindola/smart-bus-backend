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
    public class EstadoDeCuentaController : ControllerBase
    {
        private IMediator mediator;
        public EstadoDeCuentaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        [Route("{idRecorrido}/{idPasajero}")]
        public async Task<IActionResult> ObtenerEstadoDeCuentaXPasajeroYRecorrido(int idRecorrido, int idPasajero)
        {
            var response = await mediator.Send(new ObtenerEstadoDeCuentaQuery(idRecorrido, idPasajero));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarEstadoDeCuentaCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ModificarEstadoDeCuentaCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{idRecorrido}/{idPasajero}")]
        public async Task<IActionResult> Delete(int idRecorrido, int idPasajero)
        {
            var response = await mediator.Send(new EliminarEstadoDeCuentaCommand(idRecorrido, idPasajero));
            return Ok(response);
        }
    }
}
