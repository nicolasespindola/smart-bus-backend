using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Linq;

namespace SmartBus.DataAccess.Handlers
{
    class ModificarEventualidadCommandHandler : CommandHandler<ModificarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        public ModificarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Eventualidad> ResolverCommand(ModificarEventualidadCommand command, CancellationToken cancellationToken)
        {
            var eventualidad = session.Get<Eventualidad>(command.Id);

            if (eventualidad == null)
                throw new ApplicationException($"No se encontro una eventualidad con Id {command.Id}");

            if (command.FechaInicio > command.FechaFin)
                throw new ApplicationException("La fecha de inicio debe ser menor a la fecha de fin");

            if (ExisteEventualidadEnEseRangoDeFechas(command, eventualidad))
                throw new ApplicationException("Ya existe una eventualidad dentro de este rango de fechas para este recorrido y pasajero.");

            eventualidad.FechaInicio = command.FechaInicio;
            eventualidad.FechaFin = command.FechaFin;
            eventualidad.Direccion = command.Direccion;
            eventualidad.UsuarioModificacion = userContext.NombreUsuario;
            eventualidad.FechaModificacion = DateTime.Now;

            return Task.FromResult(eventualidad);
        }

        private bool ExisteEventualidadEnEseRangoDeFechas(ModificarEventualidadCommand command, Eventualidad eventualidad)
        {
            return session.Query<Eventualidad>()
                             .Any(e => !e.Eliminado && e.IdPasajero == eventualidad.IdPasajero
                                       && e.IdRecorrido == eventualidad.IdRecorrido
                                       && e.FechaInicio <= command.FechaFin
                                       && command.FechaInicio <= e.FechaFin);
        }
    }
}
