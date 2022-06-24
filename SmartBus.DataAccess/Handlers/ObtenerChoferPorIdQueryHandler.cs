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
    public class ObtenerChoferPorIdQueryHandler : IRequestHandler<ObtenerChoferPorIdQuery, Chofer>
    {
        private readonly ISession session;

        public ObtenerChoferPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Chofer> Handle(ObtenerChoferPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Chofer>().First(p => p.Id == request.Id && !p.Eliminado));
        }

    }
}
