using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Command
{
    public class EliminarEstadoDeCuentaCommand : IRequest<EstadoDeCuenta>
    {
        public int IdRecorrido { get; set; }
        public int IdPasajero { get; set; }

        public EliminarEstadoDeCuentaCommand(int idRecorrido, int idPasajero)
        {
            IdRecorrido = idRecorrido;
            IdPasajero = idPasajero;
        }
    }
}
