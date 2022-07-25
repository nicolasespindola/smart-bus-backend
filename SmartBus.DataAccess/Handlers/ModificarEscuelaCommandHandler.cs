using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SmartBus.Entities.Factories;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarEscuelaCommandHandler : CommandHandler<ModificarEscuelaCommand, Escuela>
    {
        private readonly IWebUserContext userContext;
        private readonly IEscuelaFactory escuelaFactory;
        public ModificarEscuelaCommandHandler(ISession _session, IWebUserContext _userContext, IEscuelaFactory _escuelaFactory)
            : base(_session)
        {
            userContext = _userContext;
            escuelaFactory = _escuelaFactory;
        }

        public override Task<Escuela> ResolverCommand(ModificarEscuelaCommand command, CancellationToken cancellationToken)
        {
            var escuela = escuelaFactory.Modificar(command.Id, command.Nombre, command.Direccion, command.EmailUsuarios, userContext.NombreUsuario);

            return Task.FromResult(escuela);
        }

    }
}
