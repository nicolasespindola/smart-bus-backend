using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarEventualidadCommandHandler : CommandHandler<AgregarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        public AgregarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Eventualidad> ResolverCommand(AgregarEventualidadCommand command, CancellationToken cancellationToken)
        {
            if (command.FechaInicio > command.FechaFin)
                throw new ApplicationException("La fecha de inicio debe ser menor a la fecha de fin");

            if (ExisteEventualidadEnEseRangoDeFechas(command))
                throw new ApplicationException("Ya existe una eventualidad dentro de este rango de fechas para este recorrido y pasajero.");

            var nuevoEventualidad = new Eventualidad
            {
                IdRecorrido = command.IdRecorrido,
                IdPasajero = command.IdPasajero,
                FechaInicio = command.FechaInicio,
                FechaFin = command.FechaFin,
                Direccion = command.Direccion,
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = userContext.NombreUsuario
            };

            return Task.FromResult(nuevoEventualidad);
        }

        private bool ExisteEventualidadEnEseRangoDeFechas(AgregarEventualidadCommand command)
        {
            return session.Query<Eventualidad>()
                            .Any(e => !e.Eliminado && e.IdPasajero == command.IdPasajero
                                      && e.IdRecorrido == command.IdRecorrido
                                      && e.FechaInicio <= command.FechaFin 
                                      && command.FechaInicio <= e.FechaFin);
        }
    }
}
