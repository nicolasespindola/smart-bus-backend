using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerEscuelaPorIdQuery : IRequest<Escuela>
    {
        public int Id { get; set; }

        public ObtenerEscuelaPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
