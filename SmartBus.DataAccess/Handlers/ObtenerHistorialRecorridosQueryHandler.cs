using MediatR;
using NHibernate;
using SmartBus.DataAccess.DTOs;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class ObtenerHistorialRecorridosQueryHandler : IRequestHandler<ObtenerHistorialRecorridosQuery, List<HistorialRecorridoDTO>>
    {
        private readonly ISession session;

        public ObtenerHistorialRecorridosQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<HistorialRecorridoDTO>> Handle(ObtenerHistorialRecorridosQuery request, CancellationToken cancellationToken)
        {
            var historial = session.Query<HistorialRecorrido>()
                                    .Where(h => !h.Eliminado)
                                    .Select(h => new HistorialRecorridoDTO(h))
                                    .ToList();
            return Task.FromResult(historial);
        }
    }
}
