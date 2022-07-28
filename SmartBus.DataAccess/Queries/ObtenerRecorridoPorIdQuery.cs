using MediatR;
using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerRecorridoPorIdQuery : IRequest<RecorridoDTO>
    {
        public int Id { get; set; }

        public ObtenerRecorridoPorIdQuery(int id)
        {
            Id = id;
        }
    }
}