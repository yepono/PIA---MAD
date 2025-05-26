using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Pia_2._0.Entidad;

namespace Pia_2._0.DAO
{
    internal class AlergiaPacienteDAO
    {
        public static int InsertarAlergiaPaciente(int id_alergia, int id_paciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarAlergiaPaciente @Id_Paciente = " + id_paciente + ", @Id_Alergia =  " + id_alergia + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }
        public static List<String> ListarAlergiaPorPaciente(int id)
        {
            List<String> alergias = new List<String>();
            string NombreAlergia;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ListarAlergiaPorPaciente @Id_Paciente = " + id + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    NombreAlergia = reader.GetString(0);
                    alergias.Add(NombreAlergia);  
                }
            }

            return alergias;  
        }
    }
}
