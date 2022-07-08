using SmartBus.Entities;
using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Maps
{
    public class UsuarioMap : BaseEntityMap<Usuario>
    {
        public UsuarioMap() : base()
        {
            Map(x => x.Nombre);
            Map(x => x.Apellido);
            Map(x => x.Email);
            Map(x => x.Contraseña);
            Map(x => x.TipoDeUsuario, "IdTipoDeUsuario").CustomType<TipoDeUsuario>();
        }
    }
}
