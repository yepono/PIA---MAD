using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Ausencia
    {
        public int IdAusencia { get; set; }
        public DateTime FechaRegistroAusencia { get; set; }
        public DateTime FechaInicio {  get; set; }
        public DateTime FechaFin {  get; set; }
        public int IdMedico {  get; set; }

        public Ausencia() { }   

        public Ausencia(DateTime fechaInicio, DateTime fechaFin, int idMedico)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.IdMedico = idMedico;
        }
    }
}
