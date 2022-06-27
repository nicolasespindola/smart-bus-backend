using FluentNHibernate.Mapping;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class EstadoDeCuentaMap : BaseMapConAuditoria<EstadoDeCuenta>
    {
        public EstadoDeCuentaMap()
            : base()
        {
            Map(x => x.IdRecorrido);
            Map(x => x.IdPasajero);
            Map(x => x.PagoEnero);
            Map(x => x.PagoFebrero);
            Map(x => x.PagoMarzo);
            Map(x => x.PagoAbril);
            Map(x => x.PagoMayo);
            Map(x => x.PagoJunio);
            Map(x => x.PagoJulio);
            Map(x => x.PagoAgosto);
            Map(x => x.PagoSeptiembre);
            Map(x => x.PagoOctubre);
            Map(x => x.PagoNoviembre);
            Map(x => x.PagoDiciembre);
        }
    }
}
