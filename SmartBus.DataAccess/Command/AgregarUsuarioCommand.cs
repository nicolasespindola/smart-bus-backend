using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarUsuarioCommand : IRequest<Usuario>
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}
