using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class CitaMedicaDetallada
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public bool EsActiva { get; set; }

        public string NombrePaciente { get; set; } = string.Empty;
        public string NombreMedico { get; set; } = string.Empty;
        public decimal? MontoPago { get; set; }  // Puede ser null si no ha pagado
        public string NombreClinica { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string? NotaMedica { get; set; }  // Puede ser null si no hay nota
    }
}
