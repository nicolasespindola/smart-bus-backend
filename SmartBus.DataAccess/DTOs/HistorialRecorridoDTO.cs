using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.DTOs
{
    public class HistorialRecorridoDTO
    {
        public HistorialRecorridoDTO(HistorialRecorrido historialRecorrido)
        {
            Id = historialRecorrido.Id;
            Recorrido = historialRecorrido.Recorrido;
            Paradas = historialRecorrido.Paradas.Select(p => new ParadaDTO()
            {
                Id = p.Id,
                Nombre = p.EsEscuela ? p.Escuela.Nombre : p.Pasajero.Nombre,
                FechaParada = p.FechaParada,
                Exito = p.Exito,
                Eventualidad = p.Eventualidad,
                Coordenadas = p.Coordenadas,
                Domicilio = p.Domicilio
            });
            FechaInicio = historialRecorrido.FechaInicio;
            FechaFinalizacion = historialRecorrido.FechaFinalizacion;
        }   
        public int Id { get; set; }
        public Recorrido Recorrido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public IEnumerable<ParadaDTO> Paradas { get; set; }
    }
}
