using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarPasajeroCommandHandler : CommandHandler<EliminarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        public EliminarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Pasajero> ResolverCommand(EliminarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var pasajero = session.Get<Pasajero>(command.Id);

            pasajero.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(pasajero);
        }
    }
}
