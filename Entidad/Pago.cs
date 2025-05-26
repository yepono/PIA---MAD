using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Pago
    {
        public int IdPago { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = null!;
        public DateTime FechaPago { get; set; }
        public string MomentoPago { get; set; } = null!;
        
        public Pago() { }

        public Pago (decimal monto, string metodoPago, string momentoPago)
        {
            this.Monto = monto;
            this.MetodoPago = metodoPago;
            this.MomentoPago = momentoPago;
        }
    }
}
