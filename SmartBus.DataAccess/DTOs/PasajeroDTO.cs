using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class PasajeroDTO
    {
        public PasajeroDTO(Pasajero pasajero, IEnumerable<OrdenPasajero> ordenPasajeros)
        {
            Id = pasajero.Id;
            Nombre = pasajero.Nombre;
            Apellido = pasajero.Apellido;
            FechaNacimiento = pasajero.FechaNacimiento;
            Telefono = pasajero.Telefono;
            Domicilio = pasajero.Domicilio;
            PisoDepartamento = pasajero.PisoDepartamento;
            Eventualidades = pasajero.Eventualidades;
            Tutores = pasajero.Tutores;
            var op = ordenPasajeros.FirstOrDefault(op => op.IdPasajero == pasajero.Id);
            Orden = op != null ? op.Orden : 0;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public Direccion Domicilio { get; set; }
        public string PisoDepartamento { get; set; }
        public IEnumerable<Eventualidad> Eventualidades { get; set; }
        public IEnumerable<Usuario> Tutores { get; set; }
        public int Orden { get; set; }
    }
}
