using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarPasajeroCommandHandler : CommandHandler<ModificarPasajeroCommand, Pasajero>
    {
        private readonly IWebUserContext userContext;
        public ModificarPasajeroCommandHandler(ISession _session, IWebUserContext _userContext)
            : base(_session)
        {
            userContext = _userContext;
        }

        public override Task<Pasajero> ResolverCommand(ModificarPasajeroCommand command, CancellationToken cancellationToken)
        {
            var pasajero = session.Get<Pasajero>(command.Id);

            pasajero.Nombre = command.Nombre;
            pasajero.Apellido = command.Apellido;
            pasajero.FechaNacimiento = command.FechaNacimiento;
            pasajero.Telefono = command.Telefono;
            pasajero.Domicilio = command.Domicilio;
            pasajero.PisoDepartamento = command.PisoDepartamento;
            pasajero.UsuarioModificacion = userContext.NombreUsuario;
            pasajero.FechaModificacion = DateTime.Now;

            return Task.FromResult(pasajero);
        }

    }
}
