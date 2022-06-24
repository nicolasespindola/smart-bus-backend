using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarRecorridoCommandHandler : CommandHandler<EliminarRecorridoCommand, Recorrido>
    {
        private readonly IWebUserContext userContext;
        public EliminarRecorridoCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Recorrido> ResolverCommand(EliminarRecorridoCommand command, CancellationToken cancellationToken)
        {
            var pasajero = session.Get<Recorrido>(command.Id);

            pasajero.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(pasajero);
        }
    }
}
