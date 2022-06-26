﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public bool Eliminado { get; set; }
    }
}
