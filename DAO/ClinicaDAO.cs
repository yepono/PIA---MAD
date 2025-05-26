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
    public class ClinicaDAO
    {
        public static int InsertarClinica(Clinica clinica)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Razon_Social", clinica.RazonSocial);
                comando.Parameters.AddWithValue("@Fecha_inicio", clinica.FechaInicio);
                comando.Parameters.AddWithValue("@Monto_fijo", clinica.MontoFijo);
                comando.Parameters.AddWithValue("@Monto_porcentual", clinica.MontoPorcentual);
                comando.Parameters.AddWithValue("@Id_Ubicacion", clinica.IdUbicacion);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int ActualizarClinica(Clinica clinica)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("ActualizarClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Clinica", clinica.IdClinica);
                comando.Parameters.AddWithValue("@Razon_Social", clinica.RazonSocial);
                comando.Parameters.AddWithValue("@Fecha_inicio", clinica.FechaInicio);
                comando.Parameters.AddWithValue("@Monto_fijo", clinica.MontoFijo);
                comando.Parameters.AddWithValue("@Monto_porcentual", clinica.MontoPorcentual);
                comando.Parameters.AddWithValue("@Es_activa", clinica.EsActiva);
                comando.Parameters.AddWithValue("@Id_Ubicacion", clinica.IdUbicacion);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }
        
        // buscar clincia por id
        public static Clinica ObtenerClinica(int idClinica)
        {
            Clinica clinica = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("ObtenerClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Clinica", idClinica);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        clinica = new Clinica
                        {
                            RazonSocial = lector.GetString(lector.GetOrdinal("Razon_Social")),
                            FechaInicio = lector.GetDateTime(lector.GetOrdinal("Fecha_inicio")),
                            MontoFijo = lector.GetDecimal(lector.GetOrdinal("Monto_fijo")),
                            MontoPorcentual = lector.GetDecimal(lector.GetOrdinal("Monto_porcentual")),
                            EsActiva = lector.GetBoolean(lector.GetOrdinal("Es_activa")),
                            IdUbicacion = lector.GetInt32(lector.GetOrdinal("Id_Ubicacion"))
                        };
                    }
                }
            }

            return clinica;
        }

    
        public static int DarBajaClinica(int idClinica)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("DarBajaClinica", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Clinica", idClinica);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }
    }
}
