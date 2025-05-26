using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Alergia_Paciente
    {
        public int IdAlergiaPaciente { get; set; }
        public int IdPaciente { get; set; }
        public int IdAlergia {  get; set; }
        
        public Alergia_Paciente() { }
        public Alergia_Paciente( int idAlergia, int idPaciente) 
        { 
            this.IdPaciente = idPaciente;
            this.IdAlergia = idAlergia;
        }
    }
}
