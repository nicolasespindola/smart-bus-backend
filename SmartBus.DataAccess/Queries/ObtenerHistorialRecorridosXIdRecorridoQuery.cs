using MediatR;
using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerHistorialRecorridosXIdRecorridoQuery : IRequest<List<HistorialRecorridoDTO>>
    {
        public int IdRecorrido { get; set; }

        public ObtenerHistorialRecorridosXIdRecorridoQuery(int idRecorrido)
        {
            IdRecorrido = idRecorrido;
        }
    }
}