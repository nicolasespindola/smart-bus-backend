using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Escuela : BaseEntityConAuditoria
    {
        public virtual string Nombre { get; set; }
        public virtual string Direccion { get; set; }
        public virtual float Latitud { get; set; }
        public virtual float Longitud { get; set; }
    }
}
