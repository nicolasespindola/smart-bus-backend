﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public interface IBaseEntityConAuditoria : IBaseEntity
    {
        public virtual void Eliminar(string nombreUsuarioEliminacion) { }
    }
}