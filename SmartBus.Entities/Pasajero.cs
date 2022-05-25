using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Pasajero : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string CalleDomicilio { get; set; }
        public int NumeroDomicilio { get; set; }
        public int? PisoDepartamento { get; set; }
        public string IdentificacionDepartamento { get; set; }
    }
}
