using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Paciente
    {
        public int IdPaciente {  get; set; }
        public string Nombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string SegundoApellido { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public DateTime FechaNacimiento {  get; set; }
        public string Genero { get; set; } = null!;
        public string Curp { get; set; } = null!;
        public string Observaciones { get; set; } = null!;
        public int IdUbicacion {  get; set; }

        public Paciente() { }
        public Paciente (string nombre, string primerApellido, string segundoApellido, string telefono, string correo, DateTime fechaNacimiento, string genero, string curp, string observaciones, int idUbicacion)
        {
            this.Nombre = nombre;
            this.PrimerApellido = primerApellido;
            this.SegundoApellido = segundoApellido;
            this.Telefono = telefono;
            this.Correo = correo;
            this.FechaNacimiento = fechaNacimiento;
            this.Genero = genero;
            this.Curp = curp;
            this.Observaciones = observaciones;
            this.IdUbicacion = idUbicacion;
        }
    }
}
