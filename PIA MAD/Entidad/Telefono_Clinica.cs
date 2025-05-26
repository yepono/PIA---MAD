using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Telefono_Clinica
    {
        public int IdTelefonoClinica { get; set; }
        public string Telefono { get; set; }
        public int IdClinica {  get; set; }

        public Telefono_Clinica() { }
        public Telefono_Clinica (string telefono, int idClinica)
        {
            Telefono = telefono;
            IdClinica = idClinica;
        }
    }
}
