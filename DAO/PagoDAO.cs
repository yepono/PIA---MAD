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
    internal class PagoDAO
    {
        public static int InsertarPago(Pago pago)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarPago", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@Metodo_pago", pago.MetodoPago);
                cmd.Parameters.AddWithValue("@Momento_pago", pago.MomentoPago);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }

        public static int ModificarPago(Pago pago)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ModificarPago", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Pago", pago.IdPago);
                cmd.Parameters.AddWithValue("@Monto", pago.Monto);
                cmd.Parameters.AddWithValue("@Metodo_pago", pago.MetodoPago);
                cmd.Parameters.AddWithValue("@Fecha_pago", pago.FechaPago);
                cmd.Parameters.AddWithValue("@Momento_pago", pago.MomentoPago);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }

            return retorno;
        }




    }
}
