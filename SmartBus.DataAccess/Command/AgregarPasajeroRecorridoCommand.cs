using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarPasajeroRecorridoCommand
    {
        public int IdPasajero { get; set; }
        public int Orden { get; set; }
    }
}
