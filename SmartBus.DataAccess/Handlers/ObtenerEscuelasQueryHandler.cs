using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class ObtenerEscuelasQueryHandler : IRequestHandler<ObtenerEscuelasQuery, List<Escuela>>
    {
        private readonly ISession session;

        public ObtenerEscuelasQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<Escuela>> Handle(ObtenerEscuelasQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Escuela>().Where(p => !p.Eliminado).ToList());
        }
    }
}
