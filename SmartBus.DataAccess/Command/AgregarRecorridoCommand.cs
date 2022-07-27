using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarRecorridoCommand : IRequest<Recorrido>
    {
        public string Nombre { get; set; }
        public bool EsRecorridoDeIda { get; set; }
        public DateTime Horario { get; set; }
        public int? IdEscuela { get; set; }
        public int IdChofer { get; set; }
        public IEnumerable<AgregarPasajeroRecorridoCommand> Pasajeros { get; set; }
    }

}