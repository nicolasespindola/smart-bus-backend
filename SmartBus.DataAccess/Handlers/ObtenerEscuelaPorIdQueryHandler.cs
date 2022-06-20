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
    public class ObtenerEscuelaPorIdQueryHandler : IRequestHandler<ObtenerEscuelaPorIdQuery, Escuela>
    {
        private readonly ISession session;

        public ObtenerEscuelaPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Escuela> Handle(ObtenerEscuelaPorIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<Escuela>().First(p => p.Id == request.Id && !p.Eliminado));
        }

    }
}
