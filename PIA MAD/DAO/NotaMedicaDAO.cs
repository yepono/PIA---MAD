using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Pia_2._0.DAO
{
    public class NotaMedicaDAO
    {
        public static int InsertarNota(string nota)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarNota", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nota", nota);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery(); 
            }

            return retorno;
        }

        public static int ActualizarNota(int idNota, string nota)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ActualizarNota", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Nota", idNota);
                cmd.Parameters.AddWithValue("@Nota", nota);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery(); // también retorna el número de filas afectadas
            }
            
            return retorno;
        }
    }
}
