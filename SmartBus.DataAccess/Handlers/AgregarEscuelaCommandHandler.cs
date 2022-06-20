using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarEscuelaCommandHandler : CommandHandler<AgregarEscuelaCommand, Escuela>
    {
        private readonly IWebUserContext userContext;
        public AgregarEscuelaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Escuela> ResolverCommand(AgregarEscuelaCommand command, CancellationToken cancellationToken)
        {


            var nuevaEscuela = new Escuela
            {
                Nombre = command.Nombre,
                Direccion = command.Direccion,
                UsuarioCreacion = userContext.NombreUsuario,
                FechaCreacion = DateTime.Now,
                Eliminado = false,
                
            };

            return Task.FromResult(nuevaEscuela);
        }

    }
}
