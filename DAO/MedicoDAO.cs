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
    public class MedicoDAO
    {
        public static int InsertarMedico(Medico medico)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cedula", medico.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", medico.PrimerApellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", medico.SegundoApellido);
                cmd.Parameters.AddWithValue("@Telefono", medico.Telefono);
                cmd.Parameters.AddWithValue("@Correo", medico.Correo);
                cmd.Parameters.AddWithValue("@RFC", medico.Rfc);
                cmd.Parameters.AddWithValue("@CURP", medico.Curp);
                cmd.Parameters.AddWithValue("@Cuenta_banco", medico.CuentaBanco);
                cmd.Parameters.AddWithValue("@Tarifa", medico.Tarifa);
                cmd.Parameters.AddWithValue("@Id_Especialidad", medico.IdEspecialidad);
                cmd.Parameters.AddWithValue("@Id_Ubicacion", medico.IdUbicacion);

                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    retorno = Convert.ToInt32(resultado);
                }

            }

            return retorno;
        }

        public static int ActualizarMedico(Medico medico)
        {
            int resultado = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ActualizarMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Medico", medico.IdMedico);
                cmd.Parameters.AddWithValue("@Cedula", medico.Cedula);
                cmd.Parameters.AddWithValue("@Nombre", medico.Nombre);
                cmd.Parameters.AddWithValue("@Primer_Apellido", medico.PrimerApellido);
                cmd.Parameters.AddWithValue("@Segundo_Apellido", medico.SegundoApellido);
                cmd.Parameters.AddWithValue("@Telefono", medico.Telefono);
                cmd.Parameters.AddWithValue("@Correo", medico.Correo);
                cmd.Parameters.AddWithValue("@RFC", medico.Rfc);
                cmd.Parameters.AddWithValue("@CURP", medico.Curp);
                cmd.Parameters.AddWithValue("@Cuenta_banco", medico.CuentaBanco);
                cmd.Parameters.AddWithValue("@Tarifa", medico.Tarifa);
                cmd.Parameters.AddWithValue("@Id_Especialidad", medico.IdEspecialidad);
                cmd.Parameters.AddWithValue("@Id_Ubicacion", medico.IdUbicacion);

                resultado = cmd.ExecuteNonQuery();
            }

            return resultado;
        }


        public static Medico ObtenerMedicoPorId(int idMedico)
        {
            Medico medico = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerMedicoPorId", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Doctor", idMedico);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    medico = new Medico
                    {
                        IdMedico = reader.GetInt32(reader.GetOrdinal("Id_Medico")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        PrimerApellido = reader.GetString(reader.GetOrdinal("Primer_Apellido")),
                        SegundoApellido = reader.GetString(reader.GetOrdinal("Segundo_Apellido")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        Correo = reader.GetString(reader.GetOrdinal("Correo")),
                        Tarifa = reader.GetDecimal(reader.GetOrdinal("Tarifa")),
                        Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                        CuentaBanco = reader.GetString(reader.GetOrdinal("Cuenta_banco")),
                        Curp = reader.GetString(reader.GetOrdinal("CURP")),
                        IdEspecialidad = reader.GetInt32(reader.GetOrdinal("Id_Especialidad")),
                        Rfc = reader.GetString(reader.GetOrdinal("RFC")),
                        IdUbicacion = reader.GetInt32(reader.GetOrdinal("Id_Ubicacion"))
                    };
                }
            }

            return medico;
        }

        public static List<Medico> ObtenerMedicos()
        {
            List<Medico> medicos = new List<Medico>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerMedicos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Medico medico = new Medico
                    {
                        IdMedico = reader.GetInt32(reader.GetOrdinal("Id_Medico")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        PrimerApellido = reader.GetString(reader.GetOrdinal("Primer_Apellido")),
                        SegundoApellido = reader.GetString(reader.GetOrdinal("Segundo_Apellido")),
                        Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                        Correo = reader.GetString(reader.GetOrdinal("Correo")),
                        Tarifa = reader.GetDecimal(reader.GetOrdinal("Tarifa")),
                        Cedula = reader.GetString(reader.GetOrdinal("Cedula")),
                        CuentaBanco = reader.GetString(reader.GetOrdinal("Cuenta_banco")),
                        Curp = reader.GetString(reader.GetOrdinal("CURP")),
                        IdEspecialidad = reader.GetInt32(reader.GetOrdinal("Id_Especialidad")),
                        Rfc = reader.GetString(reader.GetOrdinal("RFC")),
                        IdUbicacion = reader.GetInt32(reader.GetOrdinal("Id_Ubicacion"))

                    };

                    medicos.Add(medico);
                }

                return medicos;
            }
        }
    }
}
