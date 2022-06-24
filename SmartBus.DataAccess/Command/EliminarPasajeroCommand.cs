using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class EliminarPasajeroCommand : IRequest<Pasajero>
    {
        public int Id { get; set; }
        public EliminarPasajeroCommand(int id)
        {
            Id = id;
        }
    }
}
