using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Clinica
    {
        public int IdClinica {  get; set; }
        public string RazonSocial { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public decimal? MontoFijo { get; set; }
        public decimal? MontoPorcentual {  get; set; }
        public bool EsActiva { get; set; }
        public int IdUbicacion {  get; set; }

        public Clinica() { }
        public Clinica (string razonSocial, DateTime fechaInicio, decimal? montoFijo, decimal? montoPorcentual, bool esActiva, int idUbicacion)
        {
            if ((montoFijo.HasValue && montoPorcentual.HasValue) || (!montoFijo.HasValue && !montoPorcentual.HasValue))
            {
                throw new ArgumentException("Debe especificar solo uno: Monto Fijo o Monto Porcentual.");
            }

            this.RazonSocial = razonSocial;
            this.FechaInicio = fechaInicio;
            this.MontoFijo = montoFijo;
            this.MontoPorcentual = montoPorcentual;
            this.EsActiva = esActiva;
            this.IdUbicacion = idUbicacion;
        }
    }
}
