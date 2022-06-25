using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Command
{
    public class EliminarEventualidadCommand : IRequest<Eventualidad>
    {
        public int Id { get; set; }

        public EliminarEventualidadCommand(int id)
        {
            Id = id;
        }
    }
}
