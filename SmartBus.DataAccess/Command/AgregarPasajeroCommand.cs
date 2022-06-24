﻿using MediatR;
using SmartBus.Entities;
using System;

namespace SmartBus.DataAccess.Command
{
    public class AgregarPasajeroCommand : IRequest<Pasajero>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public Direccion Domicilio { get; set; }
        public string PisoDepartamento { get; set; }
    }

}
