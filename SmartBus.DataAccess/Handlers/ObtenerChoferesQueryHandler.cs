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
    public class ObtenerChoferesQueryHandler : IRequestHandler<ObtenerChoferesQuery, List<Chofer>>
    {
        private readonly ISession session;

        public ObtenerChoferesQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<Chofer>> Handle(ObtenerChoferesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Chofer>().Where(p => !p.Eliminado).ToList());
        }
    }
}
