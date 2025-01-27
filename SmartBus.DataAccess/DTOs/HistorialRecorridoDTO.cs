﻿using SmartBus.Entities;
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
                IdPasajero = p.Pasajero.Id,
                Nombre = p.Pasajero.Nombre,
                Apellido = p.Pasajero.Apellido,
                FechaParada = p.FechaParada,
                Exito = p.Exito
            });
            FechaInicio = historialRecorrido.FechaInicio;
            FechaFinalizacion = historialRecorrido.FechaFinalizacion;
            FechaParadaEscuela = historialRecorrido.FechaParadaEscuela;
            Interrumpido = historialRecorrido.Interrumpido;
            Irregularidades = historialRecorrido.Irregularidades;
        }   
        public int Id { get; set; }
        public Recorrido Recorrido { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaParadaEscuela { get; set; }
        public bool Interrumpido { get; set; }
        public IEnumerable<Irregularidad> Irregularidades { get; set; }
        public IEnumerable<ParadaDTO> Paradas { get; set; }
    }
}
