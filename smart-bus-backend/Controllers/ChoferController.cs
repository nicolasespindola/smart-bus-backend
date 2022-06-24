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
    public class ChoferController : ControllerBase
    {
        private IMediator mediator;
        public ChoferController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new ObtenerChoferesQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPorId(int id)
        {
            var response = await mediator.Send(new ObtenerChoferPorIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarChoferCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new EliminarChoferCommand(id));
            return Ok(response);
        }
    }
}
