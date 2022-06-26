using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public class EventualidadFactory : IEventualidadFactory
    {
        private readonly IEntityLoader entityLoader;

        public EventualidadFactory(IEntityLoader _entityLoader)
        {
            entityLoader = _entityLoader;
        }

        public Eventualidad Crear(int idRecorrido, int idPasajero, DateTime fechaInicio, DateTime fechaFin, Direccion direccion, string usuarioCreacion)
        {
            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio debe ser menor a la fecha de fin");

            if (ExisteEventualidadEnEseRangoDeFechas(idRecorrido, idPasajero, fechaInicio, fechaFin))
                throw new ApplicationException("Ya existe una eventualidad dentro de este rango de fechas para este recorrido y pasajero.");

            return new Eventualidad
            {
                IdRecorrido = idRecorrido,
                IdPasajero = idPasajero,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                Direccion = direccion,
                Eliminado = false,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = usuarioCreacion
            };
        }

        public Eventualidad Modificar(int id, DateTime fechaInicio, DateTime fechaFin, Direccion direccion, string usuarioModificacion)
        {
            var eventualidad = entityLoader.Load<Eventualidad>(id);

            if (eventualidad == null)
                throw new ApplicationException($"No se encontro una eventualidad con Id {id}");

            if (fechaInicio > fechaFin)
                throw new ApplicationException("La fecha de inicio debe ser menor a la fecha de fin");

            if (ExisteEventualidadEnEseRangoDeFechas(eventualidad.IdRecorrido, eventualidad.IdPasajero, fechaInicio, fechaFin))
                throw new ApplicationException("Ya existe una eventualidad dentro de este rango de fechas para este recorrido y pasajero.");

            eventualidad.FechaInicio = fechaInicio;
            eventualidad.FechaFin = fechaFin;
            eventualidad.Direccion = direccion;
            eventualidad.UsuarioModificacion = usuarioModificacion;
            eventualidad.FechaModificacion = DateTime.Now;

            return eventualidad;
        }

        private bool ExisteEventualidadEnEseRangoDeFechas(int idRecorrido, int idPasajero, DateTime fechaInicio, DateTime fechaFin)
        {
            return entityLoader.Query<Eventualidad>()
                            .Any(e => !e.Eliminado && e.IdPasajero == idPasajero
                                      && e.IdRecorrido == idRecorrido
                                      && e.FechaInicio <= fechaFin
                                      && fechaInicio <= e.FechaFin);
        }
    }
}
