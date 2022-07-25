using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarEscuelaCommand : IRequest<Escuela>
    {
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }
        public IEnumerable<string> EmailUsuarios { get; set; }
    }
}
