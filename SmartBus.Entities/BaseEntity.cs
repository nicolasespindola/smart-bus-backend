using System;

namespace SmartBus.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string UsuarioCreacion { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual string UsuarioModificacion { get; set; }
        public virtual DateTime? FechaModificacion { get; set; }
        public virtual string UsuarioEliminacion { get; set; }
        public virtual DateTime? FechaEliminacion { get; set; }
        public virtual bool Eliminado { get; set; }
    }
}
