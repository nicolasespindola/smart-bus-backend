using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Command
{
    public class EliminarHistorialRecorridoCommand : IRequest<HistorialRecorrido>
    {
        public int Id { get; set; }

        public EliminarHistorialRecorridoCommand(int id)
        {
            Id = id;
        }
    }
}
