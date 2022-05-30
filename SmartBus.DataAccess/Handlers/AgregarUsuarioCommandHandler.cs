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
    public class AgregarUsuarioCommandHandler : IRequestHandler<AgregarUsuarioCommand, Usuario>
    {
        private readonly ISession session;

        public AgregarUsuarioCommandHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Usuario> Handle(AgregarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (session.Query<Usuario>().Any(x => x.Email == request.Email))
                throw new Exception("Email '" + request.Email + "' ya esta tomado");

            var nuevoUsuario = new Usuario
            {
                Email = request.Email,
                Contraseña = BCryptNet.HashPassword(request.Contraseña),
                Eliminado = false
            };

            using (var transaction = session.BeginTransaction())
            {
                session.Save(nuevoUsuario);
                transaction.Commit();
            }

            return Task.FromResult(nuevoUsuario);
        }
    }
}
