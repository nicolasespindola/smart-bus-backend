using SmartBus.DataAccess.DTOs;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Data
{
    public interface IDataAccess
    {
        List<Pasajero> GetPasajeros();
        Pasajero AddPasajero(PasajeroDTO pasajeroDTO);
    }
}
