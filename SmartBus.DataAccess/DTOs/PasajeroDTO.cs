using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class PasajeroDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string CalleDomicilio { get; set; }
        public int NumeroDomicilio { get; set; }
        public int? PisoDepartamento { get; set; }
        public string IdentificacionDepartamento { get; set; }

        public static PasajeroDTO FromEntity(Pasajero pasajero)
        {
            return new()
            {
                Id = pasajero.Id,
                Nombre = pasajero.Nombre,
                Apellido = pasajero.Apellido,
                FechaNacimiento = pasajero.FechaNacimiento,
                Telefono = pasajero.Telefono,
                CalleDomicilio = pasajero.CalleDomicilio,
                NumeroDomicilio = pasajero.NumeroDomicilio,
                PisoDepartamento = pasajero.PisoDepartamento,
                IdentificacionDepartamento = pasajero.IdentificacionDepartamento
            };
        }
    }
}
