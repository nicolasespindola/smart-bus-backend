using FluentNHibernate.Mapping;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Maps
{
    public class PasajeroMap : BaseMap<Pasajero>
    {
        public PasajeroMap()
            :base()
        {
            Map(x => x.Nombre);
            Map(x => x.Apellido);
            Map(x => x.FechaNacimiento);
            Map(x => x.Telefono);
            Map(x => x.CalleDomicilio);
            Map(x => x.NumeroDomicilio);
            Map(x => x.PisoDepartamento).Nullable();
            Map(x => x.IdentificacionDepartamento);
        }
    }
}
