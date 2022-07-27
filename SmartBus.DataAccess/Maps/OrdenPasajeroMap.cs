using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class OrdenPasajeroMap : BaseEntityMap<OrdenPasajero>
    {
        public OrdenPasajeroMap()
            :base()
        {
            Map(x => x.IdRecorrido);
            Map(x => x.IdPasajero);
            Map(x => x.Orden);
        }
    }
}
