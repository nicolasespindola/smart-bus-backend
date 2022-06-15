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
    public class EliminarEscuelaCommandHandler : CommandHandler<EliminarEscuelaCommand, Escuela>
    {
        private readonly IWebUserContext userContext;
        public EliminarEscuelaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Escuela> ResolverCommand(EliminarEscuelaCommand command, CancellationToken cancellationToken)
        {
            var escuela = session.Get<Escuela>(command.Id);

            escuela.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(escuela);
        }
    }
}
