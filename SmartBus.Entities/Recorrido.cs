using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class Recorrido : BaseEntityConAuditoria
    {
        public virtual string Nombre { get; set; }
        public virtual bool EsRecorridoDeIda { get; set; }
        public virtual DateTime Horario { get; set; }
        public virtual int AñoCreacion { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual Usuario Chofer { get; set; }
        public virtual IEnumerable<Pasajero> Pasajeros { get; set; }
        public virtual IEnumerable<EstadoDeCuenta> EstadosDeCuenta { get; set; }
        public virtual IEnumerable<OrdenPasajero> OrdenPasajeros { get; set; }
    }
}
