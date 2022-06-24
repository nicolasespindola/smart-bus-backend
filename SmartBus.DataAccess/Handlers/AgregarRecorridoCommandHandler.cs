
using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarRecorridoCommandHandler : CommandHandler<AgregarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        private readonly IMediator mediator;
        public AgregarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext, IMediator _mediator)
            : base(_session)
        {
            userContext = _userContext;
            mediator = _mediator;
        }

        public override Task<Recorrido> ResolverCommand(AgregarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var nuevoRecorrido = new Recorrido
            {
                Nombre = command.Nombre,
                EsRecorridoDeIda = command.EsRecorridoDeIda,
                Horario = command.Horario,
                Escuela = command.IdEscuela.HasValue ? session.Get<Escuela>(command.IdEscuela) : null,
                Chofer = session.Get<Chofer>(command.IdChofer),
                AñoCreacion = DateTime.Now.Year,
                UsuarioCreacion = userContext.NombreUsuario,
                FechaCreacion = DateTime.Now,
                Pasajeros = SetearPasajeros(command.IdPasajeros),
                Eliminado = false
            };

            return Task.FromResult(nuevoRecorrido);
        }

        public override void PostResolverCommand(Recorrido respuesta)
        {
            foreach (Pasajero pasajero in respuesta.Pasajeros)
            {
                if (session.Query<EstadoDeCuenta>().Any(ec => !ec.Eliminado && ec.Pasajero.Id == pasajero.Id && ec.Recorrido.Id == respuesta.Id))
                {
                    throw new ApplicationException($"Ya existe un estado de cuenta para el pasajero Id {pasajero.Id} y recorrido Id {respuesta.Id}.");
                }

                var nuevoEstadoDeCuenta = new EstadoDeCuenta(respuesta, pasajero);
                nuevoEstadoDeCuenta.UsuarioCreacion = userContext.NombreUsuario;
                nuevoEstadoDeCuenta.FechaCreacion = DateTime.Now;
                nuevoEstadoDeCuenta.Eliminado = false;

                session.SaveOrUpdate(nuevoEstadoDeCuenta);
            }
        }

        private List<Pasajero> SetearPasajeros(IEnumerable<int> idPasajeros)
        {
            return session.Query<Pasajero>()
                .Where(p => idPasajeros.Contains(p.Id) && !p.Eliminado)
                .ToList();
        }
    }
}
