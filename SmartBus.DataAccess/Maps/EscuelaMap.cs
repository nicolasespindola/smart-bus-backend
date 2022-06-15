using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class EscuelaMap : BaseMapConAuditoria<Escuela>
    {
        public EscuelaMap()
                   : base()
        {
            Map(x => x.Nombre);
            Map(x => x.Direccion);
        }
    }
}
