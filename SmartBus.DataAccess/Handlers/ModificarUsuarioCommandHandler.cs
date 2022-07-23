using System.Threading;
using System.Threading.Tasks;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.DataAccess.Context;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SmartBus.DataAccess.Handlers
{
    public class ModificarUsuarioCommandHandler : CommandHandler<ModificarUsuarioCommand, Usuario>
    {
        public ModificarUsuarioCommandHandler(ISession _session)
            : base(_session)
        {
        }

        public override Task<Usuario> ResolverCommand(ModificarUsuarioCommand command, CancellationToken cancellationToken)
        {
            var usuario = session.Query<Usuario>().FirstOrDefault(u => u.Email == command.Email && !u.Eliminado);

            if (usuario == null)
            {
                throw new Exception("El Email '" + command.Email + "' no está invitado a la aplicación.");
            }

            usuario.Nombre = command.Nombre;
            usuario.Apellido = command.Apellido;
            usuario.TipoDeUsuario = command.TipoDeUsuario;
            usuario.Contraseña = BCryptNet.HashPassword(command.Contraseña);

            return Task.FromResult(usuario);
        }
    }
}
