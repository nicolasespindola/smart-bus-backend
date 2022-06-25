using MediatR;
using NHibernate;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    class ObtenerRecorridoPorIdQueryHandler : IRequestHandler<ObtenerRecorridoPorIdQuery, Recorrido>
    {
        private readonly ISession session;

        public ObtenerRecorridoPorIdQueryHandler(ISession _session)
        {
            session = _session;
        }

        public Task<Recorrido> Handle(ObtenerRecorridoPorIdQuery request, CancellationToken cancellationToken)
        {
            var recorrido = session.Query<Recorrido>().First(p => p.Id == request.Id && !p.Eliminado);
            var pasajerosFiltrado = ObtenerCambiosDeDomicilio(recorrido.Id, recorrido.Pasajeros);
            pasajerosFiltrado = ObtenerPasajerosPresentesHoy(recorrido.Id, pasajerosFiltrado);
            recorrido.Pasajeros = pasajerosFiltrado;
            return Task.FromResult(recorrido);
        }

        private IEnumerable<Pasajero> ObtenerPasajerosPresentesHoy(int idRecorrido, IEnumerable<Pasajero> pasajerosFiltrado)
        {
            return pasajerosFiltrado.Where(p => !p.Eventualidades.Any(e => !e.Eliminado && e.IdRecorrido == idRecorrido && DateTime.Now >= e.FechaInicio && DateTime.Now <= e.FechaFin && e.Direccion == null));
        }

        private IEnumerable<Pasajero> ObtenerCambiosDeDomicilio(int idRecorrido, IEnumerable<Pasajero> pasajeros)
        {
            return pasajeros.Select(p => {
                var eventualidad = p.Eventualidades.FirstOrDefault(e => !e.Eliminado && e.IdRecorrido == idRecorrido && DateTime.Now >= e.FechaInicio && DateTime.Now <= e.FechaFin);
                if (eventualidad == null)
                    return p;
                else
                {
                    if (eventualidad.Direccion != null)
                    {
                        p.Domicilio = eventualidad.Direccion;
                    }
                }

                return p;
            });
        }
    }
}
