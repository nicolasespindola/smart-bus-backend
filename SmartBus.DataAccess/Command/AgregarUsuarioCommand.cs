using MediatR;
using SmartBus.Entities;
using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarUsuarioCommand : IRequest<Usuario>
    {
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public TipoDeUsuario TipoDeUsuario { get; set; }
    }

    
}
