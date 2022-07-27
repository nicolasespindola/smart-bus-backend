using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class RecorridoMap : BaseMapConAuditoria<Recorrido>
    {
        public RecorridoMap()
            : base()
        {
            Map(x => x.Nombre);
            Map(x => x.EsRecorridoDeIda);
            Map(x => x.Horario);
            Map(x => x.AñoCreacion);
            References(x => x.Escuela, "IdEscuela");
            References(x => x.Chofer, "IdChofer");
            HasManyToMany(x => x.Pasajeros)
                .Cascade.All()
                .ParentKeyColumn("IdRecorrido")
                .ChildKeyColumn("IdPasajero")
                .Table("RecorridoPasajero");
            HasMany(x => x.EstadosDeCuenta)
                .KeyColumn("IdRecorrido")
                .Cascade
                .All();
            HasMany(x => x.OrdenPasajeros)
                .KeyColumn("IdRecorrido")
                .Table("OrdenPasajero")
                .Cascade
                .All();
        }
    }
}
