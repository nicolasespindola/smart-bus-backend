
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
using SmartBus.Entities.Factories;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarRecorridoCommandHandler : CommandHandler<AgregarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        private readonly IRecorridoFactory recorridoFactory;
        public AgregarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext, IRecorridoFactory _recorridoFactory)
            : base(_session)
        {
            userContext = _userContext;
            recorridoFactory = _recorridoFactory;
        }

        public override Task<Recorrido> ResolverCommand(AgregarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var nuevoRecorrido = recorridoFactory.Crear(command.Nombre,
                                                        command.EsRecorridoDeIda, 
                                                        command.Horario, 
                                                        command.IdEscuela, 
                                                        command.IdChofer, 
                                                        userContext.NombreUsuario, 
                                                        command.Pasajeros.Select(p => p.IdPasajero));
            session.SaveOrUpdate(nuevoRecorrido);

            var nuevoRecorridoPasajeroOrden = command.Pasajeros.Select(p =>
                new OrdenPasajero()
                {
                    IdRecorrido = nuevoRecorrido.Id,
                    IdPasajero = p.IdPasajero,
                    Orden = p.Orden
                });

            session.SaveOrUpdate(nuevoRecorridoPasajeroOrden);

            return Task.FromResult(nuevoRecorrido);
        }
    }
}
