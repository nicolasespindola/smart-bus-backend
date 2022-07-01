using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public interface IPasajeroFactory
    {
        public Pasajero Crear(string nombre, string apellido, DateTime fechaNacimiento, string telefono, Direccion domicilio, string pisoDepartamento, IEnumerable<string> emailTutores, string nombreUsuario);
        public Pasajero Modificar(int id, string nombre, string apellido, DateTime fechaNacimiento, string telefono, Direccion domicilio, string pisoDepartamento, IEnumerable<string> emailTutores, string usuarioModificacion);
    }
}
