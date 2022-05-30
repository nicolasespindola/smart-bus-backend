using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.Authentification.Handlers
{
    class ObtenerUsuarioPorIdQueryHandler : IRequestHandler<ObtenerUsuarioPorIdQuery, Usuario>
    {
        private readonly ISession session;

        public ObtenerUsuarioPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Usuario> Handle(ObtenerUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Usuario>().First(p => p.Id == request.Id && !p.Eliminado));
        }
    }
}