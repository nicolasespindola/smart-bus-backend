using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Authentification.Queries
{
    public class ObtenerUsuarioPorIdQuery : IRequest<Usuario>
    {
        public int Id { get; set; }

        public ObtenerUsuarioPorIdQuery(int id)
        {
            Id = id;
        }
    }
}
