using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    internal class TelefonoClinicaDAO
    {
        public static int InsertarTelefonoClinica (Telefono_Clinica telefonoClinica) {
            
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarTelefonoClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("Telefono", telefonoClinica.Telefono);
                comando.Parameters.AddWithValue("@Id_Clinica", telefonoClinica.IdClinica);

                retorno = comando.ExecuteNonQuery();
            }
            return retorno;
        }

        public static List<String> ObtenerTelefonosPorClincia(int idClinica)
        {
            List<String> telefonos = new List<String>();
            string telefono;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerTelefonosPorClinica @Id_Clinica = " + idClinica + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    telefono = reader.GetString(0);
                    telefonos.Add(telefono);  
                }
            }
            return telefonos;  
        }


    }
}
