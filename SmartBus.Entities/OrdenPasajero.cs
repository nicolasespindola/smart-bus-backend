using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class OrdenPasajero : BaseEntity
    {
        public virtual int IdRecorrido { get; set; }
        public virtual int IdPasajero { get; set; }
        public virtual int Orden { get; set; }
    }
}
