using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class HistorialRecorridoMap : BaseMapConAuditoria<HistorialRecorrido>
    {
        public HistorialRecorridoMap()
            : base()
        {
            References(x => x.Recorrido, "IdRecorrido");
            Map(x => x.FechaInicio);
            Map(x => x.FechaFinalizacion).Nullable();
            Map(x => x.FechaParadaEscuela).Nullable();
            HasMany(x => x.Paradas)
                .KeyColumn("IdHistorialRecorrido")
                .Inverse()
                .Cascade.All();
            HasMany(x => x.Irregularidades)
                .Table("IrregularidadesHistorialRecorrido")
                .KeyColumn("IdHistorialRecorrido")
                .Inverse()
                .Cascade.All();
            Map(x => x.Interrumpido);
        }
    }
}
