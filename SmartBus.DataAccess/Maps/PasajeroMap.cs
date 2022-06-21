using FluentNHibernate.Mapping;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public class PasajeroMap : BaseMapConAuditoria<Pasajero>
    {
        public PasajeroMap()
            :base()
        {
            Map(x => x.Nombre);
            Map(x => x.Apellido);
            Map(x => x.FechaNacimiento);
            Map(x => x.Telefono);
            Component<Direccion>(x => x.Domicilio, b =>
            {
                b.Map(c => c.Domicilio).Column("Domicilio");
                b.Component<Coordenadas>(z => z.Coordenadas, e => {
                    e.Map(c => c.Latitude).Column("Latitud");
                    e.Map(c => c.Longitude).Column("Longitud");
                });
            });
            References<Escuela>(x => x.Escuela, "IdEscuela");
            
            Map(x => x.PisoDepartamento).Nullable();
        }
    }
}
