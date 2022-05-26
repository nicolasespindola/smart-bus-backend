using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Pasajero : BaseEntity
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string CalleDomicilio { get; set; }
        public virtual int NumeroDomicilio { get; set; }
        public virtual int? PisoDepartamento { get; set; }
        public virtual string IdentificacionDepartamento { get; set; }
    }
}
