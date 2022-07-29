using MediatR;
using NHibernate;
using SmartBus.DataAccess.Context;
using SmartBus.DataAccess.DTOs;
using SmartBus.DataAccess.Queries;
using SmartBus.Entities;
using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Handlers
{
    class ObtenerRecorridoPorIdQueryHandler : IRequestHandler<ObtenerRecorridoPorIdQuery, RecorridoDTO>
    {
        private readonly ISession session;
        private readonly IWebUserContext userContext;

        public ObtenerRecorridoPorIdQueryHandler(ISession _session, IWebUserContext _userContext)
        {
            session = _session;
            userContext = _userContext;
        }

        public Task<RecorridoDTO> Handle(ObtenerRecorridoPorIdQuery request, CancellationToken cancellationToken)
        {
            var recorrido = session.Query<Recorrido>().First(p => p.Id == request.Id && !p.Eliminado);
            var pasajerosFiltrado = ObtenerPasajerosPorTipoDeUsuario(recorrido.Pasajeros);
            pasajerosFiltrado = ObtenerCambiosDeDomicilio(recorrido.Id, pasajerosFiltrado);
            pasajerosFiltrado = ObtenerPasajerosPresentesHoy(recorrido.Id, pasajerosFiltrado);
            recorrido.Pasajeros = pasajerosFiltrado;

            var recorridoDTO = new RecorridoDTO(recorrido);
            return Task.FromResult(recorridoDTO);
        }

        private IEnumerable<Pasajero> ObtenerPasajerosPorTipoDeUsuario(IEnumerable<Pasajero> pasajeros)
        {
            if (userContext.TipoDeUsuario.Equals(TipoDeUsuario.Tutor))
            {
                return pasajeros.Where(p => p.Tutores.Any(t => t.Id == userContext.Id));
            }
            else
            {
                return pasajeros;
            }
        }
        private IEnumerable<Pasajero> ObtenerPasajerosPresentesHoy(int idRecorrido, IEnumerable<Pasajero> pasajeros)
        {
            return pasajeros.Where(p => !p.Eventualidades.Any(e => !e.Eliminado && e.IdRecorrido == idRecorrido && DateTime.Now >= e.FechaInicio && DateTime.Now <= e.FechaFin && e.Direccion == null));
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
