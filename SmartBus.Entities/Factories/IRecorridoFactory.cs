using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities.Factories
{
    public interface IRecorridoFactory
    {
        Recorrido Crear(string nombre, bool esRecorridoDeIda, DateTime horario, int? idEscuela, int idChofer, string usuarioCreacion, IEnumerable<int> idPasajeros);
    }
}
