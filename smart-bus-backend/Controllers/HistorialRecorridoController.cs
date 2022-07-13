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
    public class HistorialRecorridoController : ControllerBase
    {
        private IMediator mediator;
        public HistorialRecorridoController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new ObtenerHistorialRecorridosQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route("{idRecorrido}")]
        public async Task<IActionResult> ObtenerXIdRecorrido(int idRecorrido)
        {
            var response = await mediator.Send(new ObtenerHistorialRecorridosXIdRecorridoQuery(idRecorrido));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgregarHistorialRecorridoCommand request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new EliminarHistorialRecorridoCommand(id));
            return Ok(response);
        }
    }
}
