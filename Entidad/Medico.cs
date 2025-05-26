using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Cedula {  get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido {  get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono {  get; set; }
        public string Correo {  get; set; }
        public string Rfc { get; set; }
        public string Curp {  get; set; }
        public string CuentaBanco {  get; set; }
        public decimal Tarifa { get; set; }
        public int IdEspecialidad {  get; set; }
        public int IdUbicacion {  get; set; }

        public Medico() { }
        public Medico (string cedula, string nombre, string primerApellido, string segundoApellido, string telefono, string correo, string rfc, string curp, string cuentaBanco, decimal tarifa, int idEspecialidad, int idUbicacion)
        {
            Cedula = cedula;
            Nombre = nombre;
            PrimerApellido = primerApellido;
            SegundoApellido = segundoApellido;
            Telefono = telefono;
            Correo = correo;
            Rfc = rfc;
            Curp = curp;
            CuentaBanco = cuentaBanco;
            Tarifa = tarifa;
            IdEspecialidad = idEspecialidad;
            IdUbicacion = idUbicacion;
        }
    }
}
