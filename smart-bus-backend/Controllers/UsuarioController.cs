using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartBus.Authentification.Command;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smart_bus_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsuarioController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [AllowAnonymous]
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(AutenticarUsuarioCommand command)
        {
            var respuesta = await mediator.Send(command);
            return Ok(respuesta);
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(AgregarUsuarioCommand command)
        {
            var respuesta = await mediator.Send(command);
            return Ok(new { message = "Registration successful" });
        }

        [AllowAnonymous]
        [HttpGet("verificar-mail")]
        public async Task<IActionResult> VerificarMail([FromQuery] VerificarMailUsuarioQuery query)
        {
            var respuesta = await mediator.Send(query);
            return Ok(respuesta);
        }
    }
}
