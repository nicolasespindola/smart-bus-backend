using SmartBus.Entities;
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
            Map(x => x.Email);
            Map(x => x.Contraseña);
        }
    }
}
