using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class EnfermedadDAO
    {
        public static int InsertarEnfermedad(Enfermedad enfermedad)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarEnfermedad @Enfermedad = '" + enfermedad.NombreEnfermedad + "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static int ModificarEnfermedad(Enfermedad enfermedad)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ModificarEnfermedad @Id_Enfermedad = " + enfermedad.IdEnfermedad +
                               ", @Enfermedad = '" + enfermedad.NombreEnfermedad +  "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static Enfermedad ObtenerEnfermedad(int id)
        {
            Enfermedad enfermedad = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerEnfermedad @Id_Enfermedad = " + id + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    enfermedad = new Enfermedad();
                    enfermedad.NombreEnfermedad = reader.GetString(0);             
                }
            }

            return enfermedad;
        }


        public static List<Enfermedad> ObtenerEnfermedades()
        {
            List<Enfermedad> lista = new List<Enfermedad>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT Id_enfermedad, Enfermedad FROM Enfermedad;";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Enfermedad enfermedad = new Enfermedad();
                    enfermedad.IdEnfermedad = reader.GetInt32(0);
                    enfermedad.NombreEnfermedad = reader.GetString(1);

                    lista.Add(enfermedad);
                }
            }

            return lista;
        }
    }
}
