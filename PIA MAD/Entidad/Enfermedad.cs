using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Enfermedad
    {
        public int IdEnfermedad {  get; set; }
        public string NombreEnfermedad { get; set; }

        public Enfermedad() { }

        public Enfermedad(string nombreEnfermedad) 
        {
            this.NombreEnfermedad = nombreEnfermedad;   
        }
    }
}
