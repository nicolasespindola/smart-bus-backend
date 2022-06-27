using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public interface IBaseEntityConAuditoria : IBaseEntity
    {
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioEliminacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public virtual void Eliminar(string nombreUsuarioEliminacion) { }
    }
}
