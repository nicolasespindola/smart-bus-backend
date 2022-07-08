using MediatR;
using NHibernate;
using SmartBus.DataAccess.Command;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SmartBus.DataAccess.Handlers
{
    public class AgregarUsuarioCommandHandler : CommandHandler<AgregarUsuarioCommand, Usuario>
    {
        public AgregarUsuarioCommandHandler(ISession _session)
            : base(_session)
        {
        }

        public override Task<Usuario> ResolverCommand(AgregarUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (session.Query<Usuario>().Any(x => x.Email == command.Email))
                throw new Exception("El Email '" + command.Email + "' ya esta tomado");

            var nuevoUsuario = new Usuario
            {
                Nombre = command.Nombre,
                Apellido = command.Apellido,
                Email = command.Email,
                Contraseña = BCryptNet.HashPassword(command.Contraseña),
                TipoDeUsuario = command.TipoDeUsuario,
                Eliminado = false
            };

            return Task.FromResult(nuevoUsuario);
        }
    }
}
