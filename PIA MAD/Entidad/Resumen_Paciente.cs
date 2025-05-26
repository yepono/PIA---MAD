using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Resumen_Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; } = null!;
        public string Curp { get; set; } = null!;
        public string? Observaciones { get; set; }

        // Ubicación
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null !;
        public string Colonia { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CodigoPostal { get; set; } = null!;
    }
}
