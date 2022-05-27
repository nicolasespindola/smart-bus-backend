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
        public string CalleDomicilio { get; set; }
        public int NumeroDomicilio { get; set; }
        public int? PisoDepartamento { get; set; }
        public string IdentificacionDepartamento { get; set; }
    }
}
