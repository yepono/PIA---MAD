using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Correo_Clinica
    {
        public int IdCorreoClinica {  get; set; }
        public string Correo {  get; set; }
        public int IdClinica {  get; set; }

        public Correo_Clinica() { }

        public Correo_Clinica(string correo, int idClinica)
        {
            Correo = correo;
            IdClinica = idClinica;
        }
    }
}
