using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Data
{
    public class DataAccess : IDataAccess
    {
        private List<Pasajero> _pasajeros = new();

        public DataAccess()
        {
            _pasajeros.Add(new Pasajero() { Id = 1, Nombre = "Nicolas", Apellido = "Espindola", FechaNacimiento = DateTime.Now, Telefono = "1137573317", CalleDomicilio = "Laprida", NumeroDomicilio = 1611, PisoDepartamento = 4, IdentificacionDepartamento = "B", UsuarioCreacion = "nespindola", FechaCreacion = DateTime.Now });
            _pasajeros.Add(new Pasajero() { Id = 2, Nombre = "Santiago", Apellido = "Espindola", FechaNacimiento = DateTime.Now, Telefono = "1137573317", CalleDomicilio = "America", NumeroDomicilio = 4122, UsuarioCreacion = "nespindola", FechaCreacion = DateTime.Now });
        }

        public Pasajero AddPasajero(PasajeroDTO pasajeroDTO)
        {
            Pasajero newPasajero = new() { 
                Nombre = pasajeroDTO.Nombre, 
                Apellido = pasajeroDTO.Apellido, 
                FechaNacimiento = pasajeroDTO.FechaNacimiento, 
                Telefono = pasajeroDTO.Telefono, 
                CalleDomicilio = pasajeroDTO.CalleDomicilio, 
                NumeroDomicilio = pasajeroDTO.NumeroDomicilio, 
                PisoDepartamento = pasajeroDTO.PisoDepartamento, 
                IdentificacionDepartamento = pasajeroDTO.IdentificacionDepartamento, 
                UsuarioCreacion = "nespindola", 
                FechaCreacion = DateTime.Now
            };
            newPasajero.Id = _pasajeros.Max(p => p.Id) + 1;

            _pasajeros.Add(newPasajero);

            return newPasajero;
        }

        public List<Pasajero> GetPasajeros()
        {
            return _pasajeros;
        }
    }
}
