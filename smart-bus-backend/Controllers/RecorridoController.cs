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
    public class RecorridoController : ControllerBase
    {
        private IMediator mediator;
        public RecorridoController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new ObtenerRecorridosQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var response = await mediator.Send(new ObtenerRecorridoPorIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarRecorridoCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new EliminarRecorridoCommand(id));
            return Ok(response);
        }
    }
}
