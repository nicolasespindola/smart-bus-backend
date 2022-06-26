using MediatR;
using SmartBus.Entities;
using System;

namespace SmartBus.DataAccess.Command
{
    public class ModificarEventualidadCommand : IRequest<Eventualidad>
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Direccion Direccion { get; set; }
    }

}