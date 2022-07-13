using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Parada : BaseEntityConAuditoria
    {
        public virtual int IdHistorialRecorrido { get; set; }
        public virtual Pasajero Pasajero { get; set; }
        public virtual DateTime FechaParada { get; set; }
        public virtual bool Exito { get; set; }
    }
}
