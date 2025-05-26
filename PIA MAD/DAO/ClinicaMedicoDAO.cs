using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Pia_2._0.DAO
{
    internal class ClinicaMedicoDAO
    { 
        public static int InsertarClinicaMedico(Clinica_Medico clinica_Medico)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarClinicaMedico", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Clinica", clinica_Medico.IdClinica);
                comando.Parameters.AddWithValue("@Id_Medico", clinica_Medico.IdMedico);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int EliminarClinicaMedico(int idClinicaMedico)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarClinicaMedico @Id_Clinica_Medico = @IdClinicaMedico;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdClinicaMedico", idClinicaMedico);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public List<Resumen_Medico> ListarMedicosPorClinica(int idClinica)
        {
            List<Resumen_Medico> lista = new List<Resumen_Medico>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("ListarMedicosPorClinica", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Clinica", idClinica);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Resumen_Medico medico = new Resumen_Medico
                        {
                            IdMedico = lector.GetInt32(lector.GetOrdinal("Id_Medico")),
                            Cedula = lector.GetString(lector.GetOrdinal("Cedula")),
                            NombreMedico = lector.GetString(lector.GetOrdinal("Nombre_Medico")),
                            Telefono = lector.GetString(lector.GetOrdinal("Telefono")),
                            Correo = lector.GetString(lector.GetOrdinal("Correo")),
                            Rfc = lector.GetString(lector.GetOrdinal("RFC")),
                            Tarifa = lector.GetDecimal(lector.GetOrdinal("Tarifa")),
                            Especialidad = lector.GetString(lector.GetOrdinal("Especialidad"))
                        };

                        lista.Add(medico);
                    }
                }
            }

            return lista;
        }

    }
}
