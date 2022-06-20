using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Pasajero : BaseEntityConAuditoria
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual string PisoDepartamento { get; set; }
        public virtual float Latitud { get; set; }
        public virtual float Longitud { get; set; }

    }
}
