using MediatR;
using SmartBus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.DataAccess.Command
{
    public class AgregarEstadoDeCuentaCommand : IRequest<EstadoDeCuenta>
    {
        public int IdRecorrido { get; set; }
        public int IdPasajero { get; set; }
        public bool PagoEnero { get; set; }
        public bool PagoFebrero { get; set; }
        public bool PagoMarzo { get; set; }
        public bool PagoAbril { get; set; }
        public bool PagoMayo { get; set; }
        public bool PagoJunio { get; set; }
        public bool PagoJulio { get; set; }
        public bool PagoAgosto { get; set; }
        public bool PagoSeptiembre { get; set; }
        public bool PagoOctubre { get; set; }
        public bool PagoNoviembre { get; set; }
        public bool PagoDiciembre { get; set; }

        public AgregarEstadoDeCuentaCommand(int idRecorrido, int idPasajero)
        {
            IdRecorrido = idRecorrido;
            IdPasajero = idPasajero;
            SetearMeses();
        }

        private void SetearMeses()
        {
            int mesCorriente = DateTime.Now.Month;

            if (mesCorriente > 1)
                PagoEnero = true;
            if (mesCorriente > 2)
                PagoFebrero = true;
            if (mesCorriente > 3)
                PagoMarzo = true;
            if (mesCorriente > 4)
                PagoAbril = true;
            if (mesCorriente > 5)
                PagoMayo = true;
            if (mesCorriente > 6)
                PagoJunio = true;
            if (mesCorriente > 7)
                PagoJulio = true;
            if (mesCorriente > 8)
                PagoAgosto = true;
            if (mesCorriente > 9)
                PagoSeptiembre = true;
            if (mesCorriente > 10)
                PagoOctubre = true;
            if (mesCorriente > 11)
                PagoNoviembre = true;
        }
    }
}