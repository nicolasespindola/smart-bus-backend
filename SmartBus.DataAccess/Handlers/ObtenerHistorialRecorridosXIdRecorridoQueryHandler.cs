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
    class ObtenerHistorialRecorridosXIdRecorridoQueryHandler : IRequestHandler<ObtenerHistorialRecorridosXIdRecorridoQuery, List<HistorialRecorridoDTO>>
    {
        private readonly ISession session;

        public ObtenerHistorialRecorridosXIdRecorridoQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<HistorialRecorridoDTO>> Handle(ObtenerHistorialRecorridosXIdRecorridoQuery request, CancellationToken cancellationToken)
        {
            var historial = session.Query<HistorialRecorrido>()
                                    .Where(p => p.Recorrido.Id == request.IdRecorrido && !p.Eliminado)
                                    .OrderByDescending(h => h.FechaCreacion)
                                    .Select(h => new HistorialRecorridoDTO(h))
                                    .ToList();

            return Task.FromResult(historial);
        }

    }
}
