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
    public class EliminarChoferCommandHandler : CommandHandler<EliminarChoferCommand, Chofer>
    {
        private readonly IWebUserContext userContext;
        public EliminarChoferCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Chofer> ResolverCommand(EliminarChoferCommand command, CancellationToken cancellationToken)
        {
            var chofer = session.Get<Chofer>(command.Id);

            chofer.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(chofer);
        }
    }
}
