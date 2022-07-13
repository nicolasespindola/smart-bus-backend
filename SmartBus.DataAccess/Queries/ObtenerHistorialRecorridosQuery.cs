using MediatR;
using SmartBus.Entities;
using System.Collections.Generic;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerHistorialRecorridosQuery : IRequest<List<HistorialRecorrido>>
    {
    }
}
