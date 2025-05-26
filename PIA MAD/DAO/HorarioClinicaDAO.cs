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
    public class HorarioClinicaDAO
    {
        public static int InsertarHorarioClinica(Horario_Clinica horario)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarHorarioClinica", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Dia", horario.Dia);
                for (int i = 0; i <= 23; i++)
                {
                    cmd.Parameters.AddWithValue($"@hora_{i}", typeof(Horario_Clinica).GetProperty($"Hora{i}")!.GetValue(horario));
                }
                cmd.Parameters.AddWithValue("@Id_Clinica", horario.IdClinica);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }
            return retorno;
        }

        public static int ModificarHorarioClinica(Horario_Clinica horario)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ModificarHorarioClinica", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Horario", horario.IdHorarioClinica);
                cmd.Parameters.AddWithValue("@Dia", horario.Dia);
                for (int i = 0; i <= 23; i++)
                {
                    cmd.Parameters.AddWithValue($"@hora_{i}", typeof(Horario_Clinica).GetProperty($"Hora{i}")!.GetValue(horario));
                }
                cmd.Parameters.AddWithValue("@Id_Clinica", horario.IdClinica);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }
            return retorno;
        }

        public List<Horario_Clinica> ObtenerHorariosPorClinica(int idClinica)
        {
            List<Horario_Clinica> lista = new List<Horario_Clinica>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerHorariosPorClinica", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Clinica", idClinica);

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Horario_Clinica horario = new Horario_Clinica
                        {
                            IdHorarioClinica = (int)reader["Id_Horario"],
                            Dia = reader["Dia"].ToString()!,
                            IdClinica = (int)reader["Id_Clinica"]
                        };

                        for (int i = 0; i <= 23; i++)
                        {
                            horario.GetType().GetProperty($"Hora{i}")!.SetValue(horario, (bool)reader[$"hora_{i}"]);
                        }

                        lista.Add(horario);
                    }
                }
            }

            return lista;
        }




    }
}
