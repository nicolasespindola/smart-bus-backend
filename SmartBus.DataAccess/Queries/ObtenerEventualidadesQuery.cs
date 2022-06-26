using MediatR;
using SmartBus.Entities;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerEventualidadesQuery : IRequest<List<Eventualidad>>
    {
        public int IdPasajero { get; set; }

        public ObtenerEventualidadesQuery(int idPasajero)
        {
            IdPasajero = idPasajero;
        }
    }
}
