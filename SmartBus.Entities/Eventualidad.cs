using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Eventualidad : BaseEntityConAuditoria
    {
        public virtual int IdRecorrido { get; set; }
        public virtual int IdPasajero { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual DateTime FechaFin { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}
