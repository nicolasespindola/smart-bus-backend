using MediatR;
using NHibernate;
using SmartBus.DataAccess.DTOs;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class VerificarMailUsuarioQueryHandler : IRequestHandler<VerificarMailUsuarioQuery, VerificarMailUsuarioDTO>
    {
        private readonly ISession session;

        public VerificarMailUsuarioQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<VerificarMailUsuarioDTO> Handle(VerificarMailUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = session.Query<Usuario>().FirstOrDefault(p => p.Email == request.Email && !p.Eliminado);

            if(usuario == null)
            {
                return Task.FromResult<VerificarMailUsuarioDTO>(null);
            }

            return Task.FromResult(new VerificarMailUsuarioDTO() { 
                Email = usuario.Email,
                TipoDeUsuario = usuario.TipoDeUsuario,
                FueActivado = usuario.Contraseña != null
            });
        }
    }
}