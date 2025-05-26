using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Nota_Medica
    {
        public int IdNotaMedica { get; set; }
        public string Nota { get; set; } = null!;
   
        public Nota_Medica() { }
        public Nota_Medica(string nota) { 
            this.Nota = nota;
        
        }
    }
}
