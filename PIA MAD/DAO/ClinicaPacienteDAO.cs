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
    public class ClinicaPacienteDAO
    {
        public static int InsertarClinicaPaciente(Clinica_Paciente clinica_Paciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarClinicaPaciente", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Clinica", clinica_Paciente.IdClinica);
                comando.Parameters.AddWithValue("@Id_Paciente", clinica_Paciente.IdPaciente);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int EliminarClinicaPaciente(int idClinicaPaciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarClinicaPaciente @Id_Clinica_Paciente = @IdClinicaPaciente;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdClinicaPaciente", idClinicaPaciente);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public List<Resumen_Paciente> ListarPacientesPorClinica(int idClinica)
        {
            List<Resumen_Paciente> lista = new List<Resumen_Paciente>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand("ListarPacientesPorClinica", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id_Clinica", idClinica);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Resumen_Paciente paciente = new Resumen_Paciente
                        {
                            IdPaciente = lector.GetInt32(lector.GetOrdinal("Id_Paciente")),
                            Nombre = lector.GetString(lector.GetOrdinal("Nombre")),
                            PrimerApellido = lector.GetString(lector.GetOrdinal("Primer_Apellido")),
                            SegundoApellido = lector.IsDBNull(lector.GetOrdinal("Segundo_Apellido")) // si no es null trae el segundoapellido
                                ? null
                                : lector.GetString(lector.GetOrdinal("Segundo_Apellido")),
                            Telefono = lector.GetString(lector.GetOrdinal("Telefono")),
                            Correo = lector.GetString(lector.GetOrdinal("Correo")),
                            FechaNacimiento = lector.GetDateTime(lector.GetOrdinal("Fecha_nacimiento")),
                            Genero = lector.GetString(lector.GetOrdinal("Genero")),
                            Curp = lector.GetString(lector.GetOrdinal("CURP")),
                            Observaciones = lector.IsDBNull(lector.GetOrdinal("Observaciones"))
                                ? null
                                : lector.GetString(lector.GetOrdinal("Observaciones")),
                            Calle = lector.GetString(lector.GetOrdinal("Calle")),
                            Numero = lector.GetString(lector.GetOrdinal("Numero")),
                            Colonia = lector.GetString(lector.GetOrdinal("Colonia")),
                            Ciudad = lector.GetString(lector.GetOrdinal("Ciudad")),
                            Estado = lector.GetString(lector.GetOrdinal("Estado")),
                            CodigoPostal = lector.GetString(lector.GetOrdinal("Codigo_postal"))
                        };

                        lista.Add(paciente);
                    }
                }
            }

            return lista;
        }
    }
}
