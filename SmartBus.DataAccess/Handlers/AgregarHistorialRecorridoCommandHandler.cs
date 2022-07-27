using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using SmartBus.Entities.Factories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarHistorialRecorridoCommandHandler : CommandHandler<AgregarHistorialRecorridoCommand, HistorialRecorrido>
    {
        private readonly IWebUserContext userContext;
        public AgregarHistorialRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<HistorialRecorrido> ResolverCommand(AgregarHistorialRecorridoCommand command, CancellationToken cancellationToken)
        {
            var nuevoHistorialRecorrido = new HistorialRecorrido() {
                Recorrido = session.Get<Recorrido>(command.IdRecorrido),
                FechaInicio = command.FechaInicio,
                FechaFinalizacion = command.FechaFinalizacion,
                FechaParadaEscuela = command.FechaParadaEscuela,
                Interrumpido = command.Interrumpido,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = userContext.NombreUsuario
            };
            session.SaveOrUpdate(nuevoHistorialRecorrido);

            foreach(var parada in command.Paradas)
            {
                var nuevaParada = new Parada() {
                    IdHistorialRecorrido = nuevoHistorialRecorrido.Id,
                    Pasajero = session.Get<Pasajero>(parada.IdPasajero),
                    FechaParada = parada.FechaParada,
                    Exito = parada.Exito,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = userContext.NombreUsuario
                };

                session.SaveOrUpdate(nuevaParada);
            }

            foreach(var irregularidad in command.Irregularidades)
            {
                var nuevaIrregularidad = new Irregularidad()
                {
                    IdHistorialRecorrido = nuevoHistorialRecorrido.Id,
                    FechaIrregularidad = irregularidad.FechaIrregularidad,
                    Descripcion = irregularidad.Descripcion
                };

                session.SaveOrUpdate(nuevaIrregularidad);
            }
            
            return Task.FromResult(nuevoHistorialRecorrido);
        }
    }
}