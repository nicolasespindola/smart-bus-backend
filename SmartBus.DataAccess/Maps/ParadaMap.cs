using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    class ParadaMap : BaseMapConAuditoria<Parada>
    {
        public ParadaMap()
            : base()
        {
            Map(x => x.IdHistorialRecorrido);
            References(x => x.Pasajero, "IdPasajero");
            Map(x => x.FechaParada);
            Map(x => x.Exito);
        }
    }
}
