using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Queries
{
    public class ObtenerUsuarioPorEmailQuery : IRequest<Usuario>
    {
        public string Email { get; set; }

        public ObtenerUsuarioPorEmailQuery(string email)
        {
            Email = email;
        }
    }
}
