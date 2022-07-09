using MediatR;
using NHibernate;
using SmartBus.Authentification.Command;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace SmartBus.Authentification.Handlers
{
    public class AutenticarUsuarioCommandHandler : IRequestHandler<AutenticarUsuarioCommand, RespuestaAutenticacionUsuario>
    {
        private readonly ISession session;
        private readonly IJwtUtils jwtUtils;
        public AutenticarUsuarioCommandHandler(ISession _session, IJwtUtils _jwtUtils)
        {
            session = _session;
            jwtUtils = _jwtUtils;
        }
        public Task<RespuestaAutenticacionUsuario> Handle(AutenticarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = session.Query<Usuario>().SingleOrDefault(x => x.Email == request.Email);

            // validate
            if (usuario == null || !BCryptNet.Verify(request.Password, usuario.Contraseña))
                throw new ApplicationException("El usuario y/o contraseña son incorrectos.");

            // authentication successful
            var token = jwtUtils.GenerateToken(usuario);
            var respuesta = new RespuestaAutenticacionUsuario() { Id = usuario.Id, Email = usuario.Email, Token = token, IdTipoDeUsuario = ((int)usuario.TipoDeUsuario) };

            return Task.FromResult(respuesta);
        }
    }
}
