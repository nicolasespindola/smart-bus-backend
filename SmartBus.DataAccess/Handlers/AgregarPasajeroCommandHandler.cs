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
    public class AgregarPasajeroCommandHandler : CommandHandler<AgregarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        public AgregarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Pasajero> ResolverCommand(AgregarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var nuevoPasajero = new Pasajero {
                Nombre = command.Nombre,
                Apellido = command.Apellido,
                FechaNacimiento = command.FechaNacimiento,
                Telefono = command.Telefono,
                CalleDomicilio = command.CalleDomicilio,
                NumeroDomicilio = command.NumeroDomicilio,
                PisoDepartamento = command.PisoDepartamento,
                IdentificacionDepartamento = command.IdentificacionDepartamento,
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = userContext.NombreUsuario,
            };

            return Task.FromResult(nuevoPasajero);
        }
    }
}
