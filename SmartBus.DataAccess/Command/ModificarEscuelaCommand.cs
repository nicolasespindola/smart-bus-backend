using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Command
{
    public class ModificarEscuelaCommand : IRequest<Escuela>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }
    }

}