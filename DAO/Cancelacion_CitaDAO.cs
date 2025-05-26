using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class Cancelacion_CitaDAO
    {
        public static int InsertarCancelacionCita(string Motivo_cancelacion, int id_cita)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarCancelacionCita " +
                               "@Motivo_cancelacion = '" + Motivo_cancelacion + "', " +
                               "@Id_Cita = " + id_cita + ";";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int ModificarCancelacionCIta(int id_cancelacion, string Motivo_cancelacion, int id_cita)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ModificarCancelacionCita " +
                               "@Id_Cancelacion = " + id_cancelacion + ", " +
                               "@Motivo_cancelacion = '" + Motivo_cancelacion + "', " +
                               "@Id_Cita = " + id_cita + "; ";

                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();             }

            return retorno;
        }

    }
}
