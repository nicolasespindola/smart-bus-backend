using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public class EventualidadMap : BaseMapConAuditoria<Eventualidad>
    {
        public EventualidadMap()
            : base()
        {
            Map(x => x.IdRecorrido);
            Map(x => x.IdPasajero);
            Map(x => x.FechaInicio);
            Map(x => x.FechaFin);
            Component<Direccion>(x => x.Direccion, b =>
            {
                b.Map(c => c.Domicilio).Column("Domicilio");
                b.Component<Coordenadas>(z => z.Coordenadas, e => {
                    e.Map(c => c.Latitude).Column("Latitud");
                    e.Map(c => c.Longitude).Column("Longitud");
                });
            });
        }
    }
}
