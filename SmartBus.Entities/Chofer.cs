﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Chofer : BaseEntityConAuditoria
    {
        public virtual string Nombre { get; set; }
        public virtual string Email { get; set; }
        public virtual string Contraseña { get; set; }
    }
}
