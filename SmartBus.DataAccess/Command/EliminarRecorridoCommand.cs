using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Command
{
    public class EliminarRecorridoCommand : IRequest<Recorrido>
    {
        public int Id { get; set; }
        public EliminarRecorridoCommand(int id)
        {
            Id = id;
        }
    }
}
