using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Enfermedad_Paciente
    {
        public int IdEnfermedadPaciente {  get; set; }
        public int IdEnfermedad {  get; set; }
        public int IdPaciente { get; set; }

        public Enfermedad_Paciente (int idEnfermedad, int idPaciente)
        {
            this.IdEnfermedad = idEnfermedad;
            this.IdPaciente = idPaciente;
        }
    }
}
