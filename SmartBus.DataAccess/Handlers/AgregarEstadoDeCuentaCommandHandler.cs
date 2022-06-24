using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarEstadoDeCuentaCommandHandler : CommandHandler<AgregarEstadoDeCuentaCommand, EstadoDeCuenta>
    {
        private readonly IWebUserContext userContext;
        public AgregarEstadoDeCuentaCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<EstadoDeCuenta> ResolverCommand(AgregarEstadoDeCuentaCommand command, CancellationToken cancellationToken)
        {
            if (session.Query<EstadoDeCuenta>().Any(ec => !ec.Eliminado && ec.Pasajero.Id == command.IdPasajero && ec.Recorrido.Id == command.IdRecorrido))
            {
                throw new ApplicationException($"Ya existe un estado de cuenta para el pasajero Id {command.IdPasajero} y recorrido Id {command.IdRecorrido}.");
            }

            var nuevoEstadoDeCuenta = new EstadoDeCuenta
            {
                Recorrido = session.Get<Recorrido>(command.IdRecorrido),
                Pasajero = session.Get<Pasajero>(command.IdPasajero),
                PagoEnero = command.PagoEnero,
                PagoFebrero = command.PagoFebrero,
                PagoMarzo = command.PagoMarzo,
                PagoAbril = command.PagoAbril,
                PagoMayo = command.PagoMayo,
                PagoJunio = command.PagoJunio,
                PagoJulio = command.PagoJulio,
                PagoAgosto = command.PagoAgosto,
                PagoSeptiembre = command.PagoSeptiembre,
                PagoOctubre = command.PagoOctubre,
                PagoNoviembre = command.PagoNoviembre,
                PagoDiciembre = command.PagoDiciembre,
                UsuarioCreacion = userContext.NombreUsuario,
                FechaCreacion = DateTime.Now,
                Eliminado = false
            };

            return Task.FromResult(nuevoEstadoDeCuenta);
        }

    }
}
