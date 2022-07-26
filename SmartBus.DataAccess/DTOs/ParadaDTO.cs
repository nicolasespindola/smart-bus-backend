using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class ParadaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public Coordenadas Coordenadas { get; set; }
        public DateTime FechaParada { get; set; }
        public bool Exito { get; set; }
        public string Eventualidad { get; set; }
    }
}
