using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Command
{
    public class ModificarRecorridoCommand : IRequest<Recorrido>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool EsRecorridoDeIda { get; set; }
        public DateTime Horario { get; set; }
        public int IdEscuela { get; set; }
        public IEnumerable<int> IdPasajeros { get; set; }
    }

}