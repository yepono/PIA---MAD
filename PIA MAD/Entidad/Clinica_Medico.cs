using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Clinica_Medico
    {
        public int IdClinicaMedico { get; set; }
        public bool EsActivo { get; set; }
        public int IdClinica { get; set; }
        public int IdMedico { get; set; }
        
        public Clinica_Medico() { }

        public Clinica_Medico(int idClinica, int idMedico) 
        {
            this.IdClinica = idClinica;
            this.IdMedico = idMedico;
        }

    }
}
