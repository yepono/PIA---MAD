using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class EspecialidadDAO
    {
        public static int InsertarEspecialidad(string especialidad)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarEspecialidad @Especialidad = '" + especialidad + "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();

            }

            return retorno;
        }

        public static string ObtenerEspecialidad(int idEspecialidad)
        {
            string especialidad = string.Empty;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT Especialidad FROM Especialidad WHERE Id_Especialidad = @Id_Especialidad";
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Id_Especialidad", idEspecialidad);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    especialidad = reader["Especialidad"].ToString();
                }
            }
            return especialidad;
        }
    }
}
