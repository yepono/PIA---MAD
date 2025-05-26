using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Ubicacion
    {
        public int IdUbicacion {  get; set; }
        public string Calle {  get; set; }
        public int Numero { get; set; }
        public string Colonia {  get; set; }
        public string Ciudad {  get; set; }
        public string Estado { get; set; }
        public int CodigoPostal { get; set; }

        public Ubicacion() { }
        public Ubicacion(string calle, int numero, string colonia, string ciudad, string estado, int codigoPostal)
        {
            this.Calle = calle;
            this.Numero = numero;
            this.Colonia = colonia;
            this.Ciudad = ciudad;
            this.Estado = estado;
            this.CodigoPostal = codigoPostal;
        }
    }
}
