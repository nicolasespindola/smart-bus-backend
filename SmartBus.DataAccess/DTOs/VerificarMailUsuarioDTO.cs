using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class VerificarMailUsuarioDTO
    {
        public string Email { get; set; }
        public bool FueActivado { get; set; }
        public TipoDeUsuario TipoDeUsuario { get; set; }
    }
}
