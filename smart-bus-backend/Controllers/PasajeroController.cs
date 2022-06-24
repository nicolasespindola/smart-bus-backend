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
    public class PasajeroController : ControllerBase
    {
        private IMediator mediator;
        public PasajeroController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response =  await mediator.Send(new ObtenerPasajerosQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var response = await mediator.Send(new ObtenerPasajeroPorIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarPasajeroCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ModificarPasajeroCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new EliminarPasajeroCommand(id));
            return Ok(response);
        }
    }
}
