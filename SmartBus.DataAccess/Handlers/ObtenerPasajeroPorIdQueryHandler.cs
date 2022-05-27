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
    public class ObtenerPasajeroPorIdQueryHandler : IRequestHandler<ObtenerPasajeroPorIdQuery, Pasajero>
    {
        private readonly ISession session;

        public ObtenerPasajeroPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Pasajero> Handle(ObtenerPasajeroPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Pasajero>().First(p => p.Id == request.Id && !p.Eliminado));
        }
    }
}
