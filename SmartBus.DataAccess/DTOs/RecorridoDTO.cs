using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class RecorridoDTO
    {
        public int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool EsRecorridoDeIda { get; set; }
        public virtual DateTime Horario { get; set; }
        public virtual int AñoCreacion { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual Usuario Chofer { get; set; }
        public virtual IEnumerable<PasajeroDTO> Pasajeros { get; set; }
        public virtual IEnumerable<EstadoDeCuenta> EstadosDeCuenta { get; set; }
        public virtual IEnumerable<OrdenPasajero> OrdenPasajeros { get; set; }

        public RecorridoDTO(Recorrido recorrido)
        {
            Id = recorrido.Id;
            Nombre = recorrido.Nombre;
            EsRecorridoDeIda = recorrido.EsRecorridoDeIda;
            Horario = recorrido.Horario;
            AñoCreacion = recorrido.AñoCreacion;
            Escuela = recorrido.Escuela;
            Chofer = recorrido.Chofer;
            Pasajeros = recorrido.Pasajeros.Select(p => new PasajeroDTO(p, recorrido.OrdenPasajeros));
            EstadosDeCuenta = recorrido.EstadosDeCuenta;
        }
    }
}
