using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Pia_2._0.DAO
{
    internal class UbicacionDAO
    {
        public static int InsertarUbicacion(Ubicacion ubicacion)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("InsertarUbicacion", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Calle", ubicacion.Calle);
                comando.Parameters.AddWithValue("@Numero", ubicacion.Numero);
                comando.Parameters.AddWithValue("@Colonia", ubicacion.Colonia);
                comando.Parameters.AddWithValue("@Ciudad", ubicacion.Ciudad);
                comando.Parameters.AddWithValue("@Estado", ubicacion.Estado);
                comando.Parameters.AddWithValue("@Codigo_postal", ubicacion.CodigoPostal);

                object resultado = comando.ExecuteScalar();
                if (resultado != null)
                {
                    retorno = Convert.ToInt32(resultado);
                }
            }

            return retorno;
        }

        public static int ActualizarUbicacion(Ubicacion ubicacion)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("ActualizarUbicacion", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Ubicacion", ubicacion.IdUbicacion);
                comando.Parameters.AddWithValue("@Calle", ubicacion.Calle);
                comando.Parameters.AddWithValue("@Numero", ubicacion.Numero);
                comando.Parameters.AddWithValue("@Colonia", ubicacion.Colonia);
                comando.Parameters.AddWithValue("@Ciudad", ubicacion.Ciudad);
                comando.Parameters.AddWithValue("@Estado", ubicacion.Estado);
                comando.Parameters.AddWithValue("@Codigo_postal", ubicacion.CodigoPostal);

                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }



        public static Ubicacion? ObtenerUbicacion(int idUbicacion)
        {
            Ubicacion? ubicacion = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand comando = new SqlCommand("ObtenerUbicacion", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id_Ubicacion", idUbicacion);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ubicacion = new Ubicacion
                        {
                            IdUbicacion = reader.GetInt32(0),
                            Calle = reader.GetString(1),
                            Numero = reader.GetInt32(2),
                            Colonia = reader.GetString(3),
                            Ciudad = reader.GetString(4),
                            Estado = reader.GetString(5),
                            CodigoPostal = reader.GetInt32(6)
                        };
                    }
                }
            }

            return ubicacion;
        }

    }
}
