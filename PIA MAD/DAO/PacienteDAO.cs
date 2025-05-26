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
    public class PacienteDAO
    {
        public static int InsertarPaciente(Paciente paciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarPaciente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", paciente.PrimerApellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", paciente.SegundoApellido);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", paciente.Correo);
                cmd.Parameters.AddWithValue("@Fecha_nacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", paciente.Genero);
                cmd.Parameters.AddWithValue("@CURP", paciente.Curp);
                cmd.Parameters.AddWithValue("@Observaciones", paciente.Observaciones);
                cmd.Parameters.AddWithValue("@Id_Ubicacion", paciente.IdUbicacion);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    retorno = Convert.ToInt32(resultado);
                }
            }

            return retorno;
        }

        public static int ActualizarPaciente(Paciente paciente)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ActualizarPaciente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Paciente", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", paciente.PrimerApellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", paciente.SegundoApellido);
                cmd.Parameters.AddWithValue("@Telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", paciente.Correo);
                cmd.Parameters.AddWithValue("@Fecha_nacimiento", paciente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Genero", paciente.Genero);
                cmd.Parameters.AddWithValue("@CURP", paciente.Curp);
                cmd.Parameters.AddWithValue("@Observaciones", paciente.Observaciones);
                cmd.Parameters.AddWithValue("@Id_Ubicacion", paciente.IdUbicacion);

                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }

        public static Paciente ObtenerPacientePorId(int idPaciente)
        {
            Paciente paciente = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerPacientePorId", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Paciente", idPaciente);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    paciente = new Paciente
                    {
                        IdPaciente = reader.GetInt32(reader.GetOrdinal("Id_Paciente")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        PrimerApellido = reader.GetString(reader.GetOrdinal("Primer_Apellido")),
                        SegundoApellido = reader.GetString(reader.GetOrdinal("Segundo_Apellido")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        Correo = reader.GetString(reader.GetOrdinal("Correo")),
                        FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("Fecha_nacimiento")),
                        Genero = reader.GetString(reader.GetOrdinal("Genero")),
                        Curp = reader.GetString(reader.GetOrdinal("CURP")),
                        Observaciones = reader.GetString(reader.GetOrdinal("Observaciones")),
                        IdUbicacion = reader.GetInt32(reader.GetOrdinal("Id_Ubicacion"))
                    };
                }
            }

            return paciente;
        }


        public static List<Paciente> ObtenerTodosLosPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerTodosLosPacientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Paciente paciente = new Paciente
                    {
                        IdPaciente = reader.GetInt32(reader.GetOrdinal("Id_Paciente")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        PrimerApellido = reader.GetString(reader.GetOrdinal("Primer_Apellido")),
                        SegundoApellido = reader.GetString(reader.GetOrdinal("Segundo_Apellido")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        Correo = reader.GetString(reader.GetOrdinal("Correo")),
                    };

                    pacientes.Add(paciente);
                }
            }

            return pacientes;
        }




    }
}
