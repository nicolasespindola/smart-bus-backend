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
        private readonly IPasajeroFactory pasajeroFactory;
        public AgregarHistorialRecorridoCommandHandler(ISession _session, IWebUserContext _userContext, IPasajeroFactory _pasajeroFactory)
            : base(_session)
        {
            userContext = _userContext;
            pasajeroFactory = _pasajeroFactory;
        }

        public override Task<HistorialRecorrido> ResolverCommand(AgregarHistorialRecorridoCommand command, CancellationToken cancellationToken)
        {
            var nuevoHistorialRecorrido = new HistorialRecorrido() {
                IdRecorrido = command.IdRecorrido,
                FechaInicio = command.FechaInicio,
                FechaFinalizacion = command.FechaFinalizacion,
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
            
            return Task.FromResult(nuevoHistorialRecorrido);
        }
    }
}