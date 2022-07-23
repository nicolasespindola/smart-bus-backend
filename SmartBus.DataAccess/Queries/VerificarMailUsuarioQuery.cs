using MediatR;
using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Queries
{
    public class VerificarMailUsuarioQuery : IRequest<VerificarMailUsuarioDTO>
    {
        public string Email { get; set; }
    }
}
