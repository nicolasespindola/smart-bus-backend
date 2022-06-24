using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class EliminarEstadoDeCuentaCommandHandler : CommandHandler<EliminarEstadoDeCuentaCommand, EstadoDeCuenta>
    {
        private readonly IWebUserContext userContext;
        public EliminarEstadoDeCuentaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<EstadoDeCuenta> ResolverCommand(EliminarEstadoDeCuentaCommand command, CancellationToken cancellationToken)
        {
            var escuela = session.Query<EstadoDeCuenta>().Single(ec => !ec.Eliminado 
                && ec.Recorrido.Id == command.IdRecorrido 
                && ec.Pasajero.Id == command.IdPasajero);

            escuela.Eliminar(userContext.NombreUsuario);

            return Task.FromResult(escuela);
        }
    }
}
