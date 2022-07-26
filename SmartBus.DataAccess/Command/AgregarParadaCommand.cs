using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarParadaCommand
    {
        public int? IdPasajero { get; set; }
        public int? IdEscuela { get; set; }
        public DateTime FechaParada { get; set; }
        public bool Exito { get; set; }
        public bool EsEscuela { get; set; }
        public string Eventualidad { get; set; }
        public Coordenadas Coordenadas { get; set; }
        public string Domicilio { get; set; }
    }
}
