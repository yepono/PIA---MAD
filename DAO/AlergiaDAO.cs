using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class AlergiaDAO
    {
        public static int InsertarAlergia(Alergia alergia)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarAlergia @Alergia = '" + alergia.NombreAlergia + "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static int ModificarAlergia(Alergia alergia)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ModificarAlergia @Id_Alergia = " + alergia.IdAlergia +
                               ", @Alergia = '" + alergia.NombreAlergia +  "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static Alergia ObtenerAlergia(int id)
        {
            Alergia alergia = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerAlergia @Id_Alergia = " + id + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    alergia = new Alergia();
                    alergia.NombreAlergia = reader.GetString(0);             
                }
            }

            return alergia;
        }


        public static List<Alergia> ObteneAlergias()
        {
            List<Alergia> lista = new List<Alergia>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT Id_alergia, Alergia FROM Alergia;";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Alergia alergia = new Alergia();
                    alergia.IdAlergia = reader.GetInt32(0);
                    alergia.NombreAlergia = reader.GetString(1);

                    lista.Add(alergia);
                }
            }

            return lista;
        }

    }
}
