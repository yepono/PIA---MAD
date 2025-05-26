using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Cancelacion_Cita
    {
        public int IdCancelacion { get; set; }
        public int FechaCancelacion { get; set; }
        public string MotivoCancelacion { get; set; }
        public int IdCita {  get; set; }


        public Cancelacion_Cita(string motivoCancelacion, int idCita)
        {
            this.MotivoCancelacion = motivoCancelacion;
            this.IdCita = idCita;
        }
    }
}
