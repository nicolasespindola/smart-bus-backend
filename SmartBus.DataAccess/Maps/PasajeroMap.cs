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
            Map(x => x.Domicilio);
            Map(x => x.PisoDepartamento).Nullable();
            Map(x => x.Latitud);
            Map(x => x.Longitud);

        }
    }
}
