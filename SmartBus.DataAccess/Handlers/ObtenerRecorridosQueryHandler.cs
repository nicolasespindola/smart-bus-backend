using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class ObtenerRecorridosQueryHandler : IRequestHandler<ObtenerRecorridosQuery, List<Recorrido>>
    {
        private readonly ISession session;

        public ObtenerRecorridosQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<Recorrido>> Handle(ObtenerRecorridosQuery request, CancellationToken cancellationToken)
        {
            var recorridos = session.Query<Recorrido>().Where(p => !p.Eliminado).ToList();
            return Task.FromResult(recorridos);
        }
    }
}
