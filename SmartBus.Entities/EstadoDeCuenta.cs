using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBus.Entities
{
    public class EstadoDeCuenta : BaseEntityConAuditoria
    {
        public virtual int IdRecorrido { get; set; }
        public virtual int IdPasajero { get; set; }
        public virtual bool PagoEnero { get; set; }
        public virtual bool PagoFebrero { get; set; }
        public virtual bool PagoMarzo { get; set; }
        public virtual bool PagoAbril { get; set; }
        public virtual bool PagoMayo { get; set; }
        public virtual bool PagoJunio { get; set; }
        public virtual bool PagoJulio { get; set; }
        public virtual bool PagoAgosto { get; set; }
        public virtual bool PagoSeptiembre { get; set; }
        public virtual bool PagoOctubre { get; set; }
        public virtual bool PagoNoviembre { get; set; }
        public virtual bool PagoDiciembre { get; set; }

        public EstadoDeCuenta() { }

        public EstadoDeCuenta(int idRecorrido, int idPasajero)
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
