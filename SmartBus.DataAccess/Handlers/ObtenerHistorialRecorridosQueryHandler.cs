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
    public class ObtenerHistorialRecorridosQueryHandler : IRequestHandler<ObtenerHistorialRecorridosQuery, List<HistorialRecorrido>>
    {
        private readonly ISession session;

        public ObtenerHistorialRecorridosQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<HistorialRecorrido>> Handle(ObtenerHistorialRecorridosQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<HistorialRecorrido>().Where(p => !p.Eliminado).ToList());
        }
    }
}
