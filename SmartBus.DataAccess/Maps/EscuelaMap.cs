using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class EscuelaMap : BaseMapConAuditoria<Escuela>
    {
        public EscuelaMap()
                   : base()
        {
            Map(x => x.Nombre);
            Component<Direccion>(x => x.Direccion, b =>
            {
                b.Map(c => c.Domicilio).Column("Direccion");
                b.Component<Coordenadas>(z => z.Coordenadas, e => {
                    e.Map(c => c.Latitude).Column("Latitud");
                    e.Map(c => c.Longitude).Column("Longitud");
                });
            });
            HasManyToMany(x => x.Usuarios)
                .Cascade.All()
                .ParentKeyColumn("IdEscuela")
                .ChildKeyColumn("IdUsuario")
                .Table("EscuelaUsuario");
        }
    }
}
