using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarIrregularidadCommand
    {
        public DateTime FechaIrregularidad { get; set; }
        public string Descripcion { get; set; }
    }
}
