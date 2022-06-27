
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
        public AgregarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
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
                if (session.Query<EstadoDeCuenta>().Any(ec => !ec.Eliminado && ec.IdPasajero == pasajero.Id && ec.IdRecorrido == respuesta.Id))
                {
                    throw new ApplicationException($"Ya existe un estado de cuenta para el pasajero Id {pasajero.Id} y recorrido Id {respuesta.Id}.");
                }

                var nuevoEstadoDeCuenta = new EstadoDeCuenta(respuesta.Id, pasajero.Id)
                {
                    UsuarioCreacion = userContext.NombreUsuario,
                    FechaCreacion = DateTime.Now,
                    Eliminado = false
                };

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
