using FluentNHibernate.Mapping;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class PasajeroMap : ClassMap<Pasajero>
    {
        public PasajeroMap()
        {
            Id(x => x.Id);
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
