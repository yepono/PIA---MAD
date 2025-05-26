using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class EnfermedadPacienteDAO
    {
        public static int InsertarEnfermedadPaciente(int id_enfermedad, int id_paciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarEnfermedadPaciente @Id_Paciente = " + id_paciente + ", @Id_Enfermedad =  " + id_enfermedad + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }
        public static List<String> ListarEnfermedadPorPaciente(int id)
        {
            List<String> enfermedades = new List<String>();
            string NombreEnfermedad;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ListarEnfermedadPorPaciente @Id_Paciente = " + id + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read()) 
                {
                    NombreEnfermedad = reader.GetString(0);
                    enfermedades.Add(NombreEnfermedad);  
                }
            }

            return enfermedades;  
        }

    }
}
