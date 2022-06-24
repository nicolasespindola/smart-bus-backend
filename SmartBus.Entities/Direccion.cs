using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Direccion
    {
        public virtual string Domicilio { get; set; }
        public virtual Coordenadas Coordenadas { get; set; }
    }
}
