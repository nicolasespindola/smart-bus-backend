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
    class ObtenerHistorialRecorridosXIdRecorridoQueryHandler : IRequestHandler<ObtenerHistorialRecorridosXIdRecorridoQuery, List<HistorialRecorrido>>
    {
        private readonly ISession session;

        public ObtenerHistorialRecorridosXIdRecorridoQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<List<HistorialRecorrido>> Handle(ObtenerHistorialRecorridosXIdRecorridoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<HistorialRecorrido>().Where(p => p.Recorrido.Id == request.IdRecorrido && !p.Eliminado).ToList());
        }

    }
}
