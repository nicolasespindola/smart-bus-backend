using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public interface IEscuelaFactory
    {
        public Escuela Crear(string nombre, Direccion direccion, IEnumerable<string> emailUsuarios, string usuarioCreacion);
        public Escuela Modificar(int idEscuela, string nombre, Direccion direccion, IEnumerable<string> emailUsuarios, string nombreUsuario);
    }
}
