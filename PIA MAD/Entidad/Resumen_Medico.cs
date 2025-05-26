using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Resumen_Medico
    {
        public int IdMedico { get; set; }
        public string Cedula { get; set; } = null!;
        public string NombreMedico { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rfc { get; set; } = null!;
        public decimal Tarifa { get; set; }
        public string Especialidad { get; set; } = null!;
    }
}
