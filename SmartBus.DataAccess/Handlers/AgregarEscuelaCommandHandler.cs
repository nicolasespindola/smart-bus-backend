using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using SmartBus.Entities.Factories;
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
        private readonly IEscuelaFactory escuelaFactory;
        public AgregarEscuelaCommandHandler(ISession _session, IWebUserContext _userContext, IEscuelaFactory _escuelaFactory)
            : base(_session)
        {
            userContext = _userContext;
            escuelaFactory = _escuelaFactory;
        }

        public override Task<Escuela> ResolverCommand(AgregarEscuelaCommand command, CancellationToken cancellationToken)
        {
            var nuevaEscuela = escuelaFactory.Crear(command.Nombre, 
                                                    command.Direccion, 
                                                    command.EmailUsuarios,
                                                    userContext.NombreUsuario);

            return Task.FromResult(nuevaEscuela);
        }
    }
}
