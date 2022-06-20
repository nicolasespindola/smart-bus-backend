using MediatR;
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
        public string Domicilio { get; set; }
        public string? PisoDepartamento { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
    }

}
