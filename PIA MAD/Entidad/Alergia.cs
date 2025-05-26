using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Alergia
    {
        public int IdAlergia { get; set; }
        public string NombreAlergia { get; set; } = null!;

        public Alergia() { }

        public Alergia (string alergia)
        {
            this.NombreAlergia = alergia;
        }
    }
}
