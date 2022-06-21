﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Recorrido : BaseEntityConAuditoria
    {
        public virtual string Nombre { get; set; }
        public virtual bool EsRecorridoDeVuelta { get; set; }
        public virtual DateTime Horario { get; set; }
        public virtual int AñoCreacion { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual Chofer Chofer { get; set; }
        public virtual IEnumerable<Pasajero> Pasajeros { get; set; }
    }
}
