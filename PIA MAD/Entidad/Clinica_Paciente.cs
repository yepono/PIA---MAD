using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Clinica_Paciente
    {
        public int IdClinicaPaciente { get; set; }
        public int IdClinica { get; set; }
        public int IdPaciente { get; set; }
        public bool EsActivo { get; set; }

        public Clinica_Paciente (int idClinica, int idPaciente)
        {
            this.IdClinica = idClinica;
            this.IdPaciente = idPaciente;
        }
    }
}
