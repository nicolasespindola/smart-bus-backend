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
    public class ObtenerPasajerosQueryHandler : IRequestHandler<ObtenerPasajerosQuery, List<Pasajero>>
    {
        private readonly ISession session;

        public ObtenerPasajerosQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<Pasajero>> Handle(ObtenerPasajerosQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Pasajero>().Where(p => !p.Eliminado).ToList());
        }
    }
}
