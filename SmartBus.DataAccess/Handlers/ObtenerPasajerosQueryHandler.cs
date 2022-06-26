using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using SmartBus.Entities.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    public class ObtenerPasajerosQueryHandler : IRequestHandler<ObtenerPasajerosQuery, List<Pasajero>>
    {
        private readonly ISession session;
        private readonly IRepositorio<Pasajero> repositorio;

        public ObtenerPasajerosQueryHandler(ISession _session, IRepositorio<Pasajero> _repositorio)
        {
            session = _session;
            repositorio = _repositorio;
        }

        public Task<List<Pasajero>> Handle(ObtenerPasajerosQuery request, CancellationToken cancellationToken)
        {
            var query = repositorio.Query();
            return Task.FromResult(session.Query<Pasajero>().Where(p => !p.Eliminado).ToList());
        }
    }
}
