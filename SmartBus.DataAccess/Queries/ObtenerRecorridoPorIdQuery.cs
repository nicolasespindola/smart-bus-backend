using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerRecorridoPorIdQuery : IRequest<Recorrido>
    {
        public int Id { get; set; }

        public ObtenerRecorridoPorIdQuery(int id)
        {
            Id = id;
        }
    }
}