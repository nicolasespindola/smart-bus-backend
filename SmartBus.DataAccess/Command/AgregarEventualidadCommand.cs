using MediatR;
using SmartBus.Entities;
using System;

namespace SmartBus.DataAccess.Command
{
    public class AgregarEventualidadCommand : IRequest<Eventualidad>
    {
        public int IdRecorrido { get; set; }
        public int IdPasajero { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Direccion Direccion { get; set; }
    }

}
