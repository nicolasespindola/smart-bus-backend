using SmartBus.Entities.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Context
{
    public interface IWebUserContext
    {
        string NombreUsuario { get; }
        int Id { get; }
        TipoDeUsuario TipoDeUsuario { get; }
    }
}
