using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Linq;
using SmartBus.Entities.Base;
using SmartBus.Entities.Factories;

namespace SmartBus.DataAccess.Handlers
{
    class ModificarEventualidadCommandHandler : CommandHandler<ModificarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        private readonly IEventualidadFactory eventualidadFactory;

        public ModificarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext, IEventualidadFactory _eventualidadFactory)
            : base(_session)
        {
            userContext = _userContext;
            eventualidadFactory = _eventualidadFactory;
        }

        public override Task<Eventualidad> ResolverCommand(ModificarEventualidadCommand command, CancellationToken cancellationToken)
        {
            var eventualidad = eventualidadFactory.Modificar(command.Id,
                                                             command.FechaInicio,
                                                             command.FechaFin,
                                                             command.Direccion,
                                                             userContext.NombreUsuario);
            return Task.FromResult(eventualidad);
        }
    }
}
