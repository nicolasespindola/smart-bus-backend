using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    class ObtenerRecorridoPorIdQueryHandler : IRequestHandler<ObtenerRecorridoPorIdQuery, Recorrido>
    {
        private readonly ISession session;

        public ObtenerRecorridoPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Recorrido> Handle(ObtenerRecorridoPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Recorrido>().First(p => p.Id == request.Id && !p.Eliminado));
        }

    }
}
