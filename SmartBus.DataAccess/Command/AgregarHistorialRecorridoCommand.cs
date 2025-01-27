﻿using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Command
{
    public class AgregarHistorialRecorridoCommand : IRequest<HistorialRecorrido>
    {
        public int IdRecorrido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public IEnumerable<AgregarParadaCommand> Paradas { get; set; }
        public DateTime? FechaParadaEscuela { get; set; }
        public bool Interrumpido { get; set; }
        public IEnumerable<AgregarIrregularidadCommand> Irregularidades { get; set; }
    }

}