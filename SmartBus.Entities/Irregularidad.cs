using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Irregularidad : BaseEntity
    {
        public virtual int IdHistorialRecorrido { get; set; }
        public virtual DateTime FechaIrregularidad { get; set; }
        public virtual string Descripcion { get; set; }
    }
}
