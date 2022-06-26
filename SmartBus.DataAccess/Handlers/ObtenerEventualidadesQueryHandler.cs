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
    public class ObtenerEventualidadesQueryHandler : IRequestHandler<ObtenerEventualidadesQuery, List<Eventualidad>>
    {
        private readonly ISession session;

        public ObtenerEventualidadesQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<Eventualidad>> Handle(ObtenerEventualidadesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Eventualidad>().Where(e => !e.Eliminado && e.IdPasajero == request.IdPasajero).ToList());
        }

    }
}