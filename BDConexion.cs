using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0

{
    public class BDConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=PIA_MAD;Data Source=DESKTOP-AJUQO01\\SQLSERVEREXPRESS");

            conexion.Open();
            return conexion;
        }
    }
}
