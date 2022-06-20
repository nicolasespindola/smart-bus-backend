using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class ChoferMap : BaseMapConAuditoria<Chofer>
    {
        public ChoferMap()
                   : base()
        {
            Map(x => x.Nombre);
            Map(x => x.Email);
            Map(x => x.Contraseña);
        }
    }
}
