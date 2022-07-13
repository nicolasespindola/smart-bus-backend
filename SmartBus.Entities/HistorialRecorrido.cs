﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class HistorialRecorrido : BaseEntityConAuditoria
    {
        public virtual int IdRecorrido { get; set; }
        public virtual DateTime FechaInicio { get; set; }
        public virtual DateTime FechaFinalizacion { get; set; }
        public virtual IEnumerable<Parada> Paradas { get; set; }
    }
}