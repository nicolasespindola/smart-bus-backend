﻿using System;

namespace SmartBus.Entities
{
    public class BaseEntityConAuditoria : BaseEntity, IBaseEntityConAuditoria
    {
        public virtual string UsuarioCreacion { get; set; }
        public virtual DateTime FechaCreacion { get; set; }
        public virtual string UsuarioModificacion { get; set; }
        public virtual DateTime? FechaModificacion { get; set; }
        public virtual string UsuarioEliminacion { get; set; }
        public virtual DateTime? FechaEliminacion { get; set; }

        public virtual void Eliminar(string nombreUsuarioEliminacion)
        {
            this.Eliminado = true;
            this.FechaEliminacion = DateTime.Now;
            this.UsuarioEliminacion = nombreUsuarioEliminacion;
        }
    }
}
