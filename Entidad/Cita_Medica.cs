using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Cita_Medica
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int IdClinica { get; set; }
        public int IdNota {  get; set; }
        public int IdPago { get; set; }
        public int IdEspecialidad {  get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public string? Motivo { get; set; }
        public bool EsActiva { get; set; }

        public Cita_Medica() { }
        public Cita_Medica(DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, int idClinica, int idNota, int idPago, int idEspecialidad, int idPaciente, int idMedico, string? motivo)
        {
            this.Fecha = fecha;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.IdClinica = idClinica;
            this.IdNota = idNota;
            this.IdPago = idPago;
            this.IdEspecialidad = idEspecialidad;
            this.IdPaciente = idPaciente;
            this.IdMedico = idMedico;
            this.Motivo = motivo;
        }
    }
}
