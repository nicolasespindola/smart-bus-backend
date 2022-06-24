using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerEstadoDeCuentaQuery : IRequest<EstadoDeCuenta>
    {
        public int IdRecorrido { get; set; }
        public int IdPasajero { get; set; }
        
        public ObtenerEstadoDeCuentaQuery() { }
        public ObtenerEstadoDeCuentaQuery(int idRecorrido, int idPasajero)
        {
            IdRecorrido = idRecorrido;
            IdPasajero = idPasajero;
        }
    }
}
