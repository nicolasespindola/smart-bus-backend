using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using SmartBus.Entities.Factories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarEventualidadCommandHandler : CommandHandler<AgregarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        private readonly IEventualidadFactory eventualidadFactory;

        public AgregarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext, IEventualidadFactory _eventualidadFactory)
            : base(_session)
        {
            userContext = _userContext;
            eventualidadFactory = _eventualidadFactory;
        }

        public override Task<Eventualidad> ResolverCommand(AgregarEventualidadCommand command, CancellationToken cancellationToken)
        {
            var nuevoEventualidad = eventualidadFactory.Crear(command.IdRecorrido, 
                                                              command.IdPasajero, 
                                                              command.FechaInicio, 
                                                              command.FechaFin, 
                                                              command.Direccion, 
                                                              userContext.NombreUsuario);

            return Task.FromResult(nuevoEventualidad);
        }
    }
}
