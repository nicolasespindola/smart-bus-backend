using MediatR;
using SmartBus.Entities;

namespace SmartBus.DataAccess.Command
{
    public class ModificarEstadoDeCuentaCommand : IRequest<EstadoDeCuenta>
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
    }

}