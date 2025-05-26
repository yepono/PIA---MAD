using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Clinica_Especialidad
    {
        public int IdClinicaEspecialidad {  get; set; }
        public int IdClinica {  get; set; }
        public int IdEspecialidad { get; set; }

        public Clinica_Especialidad(int idClinica, int idEspecialidad)
        {
            IdClinica = idClinica;
            IdEspecialidad = idEspecialidad;
        }
    }
}
