using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class CorreoClinicaDAO
    {
        public static int InsertarCorreoClinica (Correo_Clinica correoClinica) {
            
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarCorreoClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("Correo", correoClinica.Correo);
                comando.Parameters.AddWithValue("@Id_Clinica", correoClinica.IdClinica);

                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static List<String> InsertarCorreoClincia(int idCorreo)
        {
            List<String> correos = new List<String>();
            string correo;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerCorreosPorClinica @Id_Clincia = " + idCorreo + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    correo = reader.GetString(0);
                    correos.Add(correo);  
                }
            }
            return correos;  
        }
    }
}
