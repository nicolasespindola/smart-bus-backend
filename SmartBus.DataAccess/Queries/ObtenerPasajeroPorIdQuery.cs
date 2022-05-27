using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerPasajeroPorIdQuery : IRequest<Pasajero>
    {
        public int Id { get; set; }

        public ObtenerPasajeroPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
