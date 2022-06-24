using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Authentification
{
    public interface IJwtUtils
    {
        public string GenerateToken(Usuario user);
        public int? ValidateToken(string token);
    }
}
