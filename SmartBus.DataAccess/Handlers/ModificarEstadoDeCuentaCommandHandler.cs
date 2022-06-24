using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Linq;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarEstadoDeCuentaCommandHandler : CommandHandler<ModificarEstadoDeCuentaCommand, EstadoDeCuenta>
    {
        private readonly IWebUserContext userContext;
        public ModificarEstadoDeCuentaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<EstadoDeCuenta> ResolverCommand(ModificarEstadoDeCuentaCommand command, CancellationToken cancellationToken)
        {
            var estadoDeCuenta = session.Query<EstadoDeCuenta>()
                .Single(ec => !ec.Eliminado
                    && ec.Recorrido.Id == command.IdRecorrido
                    && ec.Pasajero.Id == command.IdPasajero);

            estadoDeCuenta.PagoEnero = command.PagoEnero;
            estadoDeCuenta.PagoFebrero = command.PagoFebrero;
            estadoDeCuenta.PagoMarzo = command.PagoMarzo;
            estadoDeCuenta.PagoAbril = command.PagoAbril;
            estadoDeCuenta.PagoMayo = command.PagoMayo;
            estadoDeCuenta.PagoJunio = command.PagoJunio;
            estadoDeCuenta.PagoJulio = command.PagoJulio;
            estadoDeCuenta.PagoAgosto = command.PagoAgosto;
            estadoDeCuenta.PagoSeptiembre = command.PagoSeptiembre;
            estadoDeCuenta.PagoOctubre = command.PagoOctubre;
            estadoDeCuenta.PagoNoviembre = command.PagoNoviembre;
            estadoDeCuenta.PagoDiciembre = command.PagoDiciembre;
            estadoDeCuenta.UsuarioModificacion = userContext.NombreUsuario;
            estadoDeCuenta.FechaModificacion = DateTime.Now;

            return Task.FromResult(estadoDeCuenta);
        }

    }
}
