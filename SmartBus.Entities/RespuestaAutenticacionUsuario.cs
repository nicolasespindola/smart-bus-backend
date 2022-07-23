using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class RespuestaAutenticacionUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public int IdTipoDeUsuario { get; set; }
    }
}
