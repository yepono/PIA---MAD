using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Especialidad
    {
        public int IdEspecialidad {  get; set; }
        public string NombreEspecialidad { get; set; }

        public Especialidad() { }
        public Especialidad (string nombreEspecialidad)
        {
            NombreEspecialidad = nombreEspecialidad;
        }
    }
}
