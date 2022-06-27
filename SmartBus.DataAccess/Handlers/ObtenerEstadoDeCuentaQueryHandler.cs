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
    public class ObtenerEstadoDeCuentaQueryHandler : IRequestHandler<ObtenerEstadoDeCuentaQuery, EstadoDeCuenta>
    {
        private readonly ISession session;

        public ObtenerEstadoDeCuentaQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<EstadoDeCuenta> Handle(ObtenerEstadoDeCuentaQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(session.Query<EstadoDeCuenta>()
                .Where(
                    p => !p.Eliminado
                    && p.IdRecorrido == request.IdRecorrido 
                    && p.IdPasajero == request.IdPasajero
                ).Single());
        }
    }
}
