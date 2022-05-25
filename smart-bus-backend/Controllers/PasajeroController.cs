using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartBus.DataAccess.DTOs;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_bus_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasajeroController : ControllerBase
    {
        private IMediator _mediator;
        public PasajeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response =  await _mediator.Send(new ObtenerPasajerosQuery());
            return Ok(response);
        }
    }
}
