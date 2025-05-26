using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Pia_2._0.DAO
{
    internal class ClinicaEspecialidadDAO
    {
        public static int InsertarEspecialidadClinica(Clinica_Especialidad clinica_Especialidad)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarEspecialidadClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Especialidad", clinica_Especialidad.IdEspecialidad);
                comando.Parameters.AddWithValue("@Id_Clinica", clinica_Especialidad.IdClinica);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static List<Especialidad> ObtenerEspecialidadesPorClinica(int id)
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerEspecialidadesPorClinica " +
                               "@Id_Clinica = " + id + " ;" ;
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.IdEspecialidad = reader.GetInt32(0);             
                    especialidad.NombreEspecialidad = reader.GetString(1);              

                    especialidades.Add(especialidad);
                }
            }

            return especialidades;
        }

    }
}
