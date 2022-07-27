using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public class IrregularidadMap : BaseEntityMap<Irregularidad>
    {
        public IrregularidadMap()
            : base()
        {
            Map(x => x.IdHistorialRecorrido);
            Map(x => x.FechaIrregularidad);
            Map(x => x.Descripcion);
            Table("IrregularidadesHistorialRecorrido");
        }
    }
}
