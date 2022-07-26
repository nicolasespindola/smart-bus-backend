using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    class ParadaMap : BaseMapConAuditoria<Parada>
    {
        public ParadaMap()
            : base()
        {
            Map(x => x.IdHistorialRecorrido);
            References(x => x.Pasajero, "IdPasajero").Nullable();
            References(x => x.Escuela, "IdEscuela").Nullable();
            Map(x => x.FechaParada);
            Map(x => x.Exito);
            Map(x => x.EsEscuela);
            Map(x => x.Eventualidad).Nullable();
            Map(c => c.Domicilio).Column("Domicilio");
            Component<Coordenadas>(z => z.Coordenadas, e => {
                e.Map(c => c.Latitude).Column("Latitud");
                e.Map(c => c.Longitude).Column("Longitud");
            });
        }
    }
}
