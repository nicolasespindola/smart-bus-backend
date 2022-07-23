using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    class EliminarHistorialRecorridoCommandHandler : CommandHandler<EliminarHistorialRecorridoCommand, HistorialRecorrido>
    {
        private readonly IWebUserContext userContext;
        public EliminarHistorialRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<HistorialRecorrido> ResolverCommand(EliminarHistorialRecorridoCommand command, CancellationToken cancellationToken)
        {
            var eventualidad = session.Get<HistorialRecorrido>(command.Id);

            eventualidad.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(eventualidad);
        }
    }
}
