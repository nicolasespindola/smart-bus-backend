using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarEventualidadCommandHandler : CommandHandler<EliminarEventualidadCommand, Eventualidad>
    {
        private readonly IWebUserContext userContext;
        public EliminarEventualidadCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Eventualidad> ResolverCommand(EliminarEventualidadCommand command, CancellationToken cancellationToken)
        {
            var eventualidad = session.Get<Eventualidad>(command.Id);

            eventualidad.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(eventualidad);
        }
    }
}
