using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Parada : BaseEntityConAuditoria
    {
        public virtual int IdHistorialRecorrido { get; set; }
        public virtual Pasajero Pasajero { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual string Domicilio { get; set; }
        public virtual Coordenadas Coordenadas { get; set; }
        public virtual DateTime FechaParada { get; set; }
        public virtual bool EsEscuela { get; set; }
        public virtual bool Exito { get; set; }
        public virtual string Eventualidad { get; set; }
    }
}
