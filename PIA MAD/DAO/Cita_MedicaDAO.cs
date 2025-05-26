using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class Cita_MedicaDAO
    {
        public static int InsertarCitaMedica(Cita_Medica cita)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarCitaMedica " +
                    "@Fecha = @Fecha, " +
                    "@Hora_ini = @HoraInicio, " +
                    "@Hora_fin = @HoraFin, " +
                    "@Motivo = @Motivo, " +
                    "@Id_Medico = @IdMedico, " +
                    "@Id_Paciente = @IdPaciente, " +
                    "@Id_Clinica = @IdClinica, " +
                    "@Id_Especialidad = @IdEspecialidad, " +
                    "@Id_Nota = @IdNota, " +
                    "@Id_Pago = @IdPago;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Fecha", cita.Fecha);
                comando.Parameters.AddWithValue("@HoraInicio", cita.HoraInicio);
                comando.Parameters.AddWithValue("@HoraFin", cita.HoraFin);
                comando.Parameters.AddWithValue("@Motivo", (object?)cita.Motivo ?? DBNull.Value);
                comando.Parameters.AddWithValue("@IdMedico", cita.IdMedico);
                comando.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente);
                comando.Parameters.AddWithValue("@IdClinica", cita.IdClinica);
                comando.Parameters.AddWithValue("@IdEspecialidad", cita.IdEspecialidad);
                comando.Parameters.AddWithValue("@IdNota", cita.IdNota);
                comando.Parameters.AddWithValue("@IdPago", cita.IdPago);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int ModificarCitaMedica(Cita_Medica cita)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ModificarCitaMedica " +
                    "@Id_Cita = @IdCita, " +
                    "@Fecha = @Fecha, " +
                    "@Hora_ini = @HoraInicio, " +
                    "@Hora_fin = @HoraFin, " +
                    "@Motivo = @Motivo, " +
                    "@Id_Medico = @IdMedico, " +
                    "@Id_Paciente = @IdPaciente, " +
                    "@Id_Clinica = @IdClinica, " +
                    "@Id_Especialidad = @IdEspecialidad, " +
                    "@Id_Nota = @IdNota, " +
                    "@Id_Pago = @IdPago;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdCita", cita.IdCita);
                comando.Parameters.AddWithValue("@Fecha", cita.Fecha);
                comando.Parameters.AddWithValue("@HoraInicio", cita.HoraInicio);
                comando.Parameters.AddWithValue("@HoraFin", cita.HoraFin);
                comando.Parameters.AddWithValue("@Motivo", (object?)cita.Motivo ?? DBNull.Value);
                comando.Parameters.AddWithValue("@IdMedico", cita.IdMedico);
                comando.Parameters.AddWithValue("@IdPaciente", cita.IdPaciente);
                comando.Parameters.AddWithValue("@IdClinica", cita.IdClinica);
                comando.Parameters.AddWithValue("@IdEspecialidad", cita.IdEspecialidad);
                comando.Parameters.AddWithValue("@IdNota", cita.IdNota);
                comando.Parameters.AddWithValue("@IdPago", cita.IdPago);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int EliminarCitaMedica(int idCita)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC EliminarCitaMedica @Id_Cita = @IdCita;";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdCita", idCita);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static CitaMedicaDetallada? ObtenerCitaDetalladaPorId(int idCita)
        {
            CitaMedicaDetallada? cita = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerDetalleCitaMedica @Id_Cita = " + idCita + ";";
                SqlCommand comando = new SqlCommand(query, conexion);

                // ejecuta la consulta del SqlCommand y regresa un SqlDataReader, que se usa para leer los datos obtenidos.
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        cita = new CitaMedicaDetallada
                        {
                            IdCita = lector.GetInt32(lector.GetOrdinal("Id_Cita")), // get ordinal obtiene el índice de columna para "Id_Cita"
                            Fecha = lector.GetDateTime(lector.GetOrdinal("Fecha")),
                            HoraInicio = lector.GetTimeSpan(lector.GetOrdinal("Hora_ini")),
                            HoraFin = lector.GetTimeSpan(lector.GetOrdinal("Hora_fin")),
                            Motivo = lector.GetString(lector.GetOrdinal("Motivo")),
                            EsActiva = lector.GetBoolean(lector.GetOrdinal("Es_activa")),

                            NombrePaciente = lector.GetString(lector.GetOrdinal("Nombre_Paciente")),
                            NombreMedico = lector.GetString(lector.GetOrdinal("Nombre_Medico")),
                            // Si el campo es nulo se obtiene el valor null de c#, de lo contrario se obtiene el valor de la bd
                            MontoPago = lector.IsDBNull(lector.GetOrdinal("Monto_Pago"))
                                ? null
                                : lector.GetDecimal(lector.GetOrdinal("Monto_Pago")),
                            NombreClinica = lector.GetString(lector.GetOrdinal("Nombre_Clinica")),
                            Especialidad = lector.GetString(lector.GetOrdinal("Especialidad")),
                            NotaMedica = lector.IsDBNull(lector.GetOrdinal("Nota_Medica"))
                                ? null
                                : lector.GetString(lector.GetOrdinal("Nota_Medica"))
                        };
                    }
                }
            }

            return cita;
        }


    }
}
