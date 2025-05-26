using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class AusenciaDAO
    {
        public static int InsertarAusencia(Ausencia ausencia)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarAusencia " +
                               "@Fecha_ini = '" + ausencia.FechaInicio.ToString("yyyy-MM-dd") + "', " +
                               "@Fecha_fin = '" + ausencia.FechaFin.ToString("yyyy-MM-dd") + "', " +
                               "@Id_Medico = " + ausencia.IdMedico + ";";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int ModificarAusencia(Ausencia ausencia)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ModificarAusencia " +
                               "@Id_Ausencia = " + ausencia.IdAusencia + ", " +
                               "@Fecha_ini = '" + ausencia.FechaInicio.ToString("yyyy-MM-dd") + "', " +
                               "@Fecha_fin = '" + ausencia.FechaFin.ToString("yyyy-MM-dd") + "', " +
                               "@Id_Medico = " + ausencia.IdMedico + ";";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery(); // Ejecuta y obtiene número de filas afectadas
            }

            return retorno;
        }


        public static List<Ausencia> ObtenerAusenciasPorMedico(int id)
        {
            List<Ausencia> ausencias = new List<Ausencia>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerAusenciasPorMedico " +
                               "@Id_Medico = " + id + " ;" ;
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Ausencia ausencia = new Ausencia();
                    ausencia.IdAusencia = reader.GetInt32(0);             
                    ausencia.FechaRegistroAusencia = reader.GetDateTime(1);         
                    ausencia.FechaInicio = reader.GetDateTime(2);          
                    ausencia.FechaFin = reader.GetDateTime(3);             

                    ausencias.Add(ausencia);
                }
            }

            return ausencias;
        }

    }
}
