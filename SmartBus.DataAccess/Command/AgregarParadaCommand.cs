using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarParadaCommand
    {
        public int IdPasajero { get; set; }
        public DateTime FechaParada { get; set; }
        public bool Exito { get; set; }
    }
}
