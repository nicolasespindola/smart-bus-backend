using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public interface IEventualidadFactory
    {
        public Eventualidad Crear(int idRecorrido, int idPasajero, DateTime fechaInicio, DateTime fechaFin, Direccion direccion, string usuarioCreacion);
        public Eventualidad Modificar(int id, DateTime fechaInicio, DateTime fechaFin, Direccion direccion, string usuarioModificacion);
    }
}
