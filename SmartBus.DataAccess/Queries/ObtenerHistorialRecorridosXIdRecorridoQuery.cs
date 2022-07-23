using MediatR;
using SmartBus.Entities;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerHistorialRecorridosXIdRecorridoQuery : IRequest<List<HistorialRecorrido>>
    {
        public int IdRecorrido { get; set; }

        public ObtenerHistorialRecorridosXIdRecorridoQuery(int idRecorrido)
        {
            IdRecorrido = idRecorrido;
        }
    }
}