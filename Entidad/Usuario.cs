using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.Entidad
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Contra { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public bool EsActivo { get; set; }

        public Usuario() { }

        public Usuario(string contra, string rol)
        {
            this.Contra = contra;
            this.Rol = rol;
        }
    }
}
