using System;
using Pia_2._0.Entidad;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class HorarioMedicoDAO
    {
        public static int InsertarHorarioMedico(Horario_Medico horario)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("InsertarHorarioMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Dia", horario.Dia);
                for (int i = 0; i <= 23; i++)
                {
                    cmd.Parameters.AddWithValue($"@hora_{i}", typeof(Horario_Clinica).GetProperty($"Hora{i}")!.GetValue(horario));
                }
                cmd.Parameters.AddWithValue("@Id_Medico", horario.IdMedico);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }
            return retorno;
        }

        public static int ModificarHorarioMedico(Horario_Medico horario)
        {
            int retorno = 0;
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ModificarHorarioMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Horario", horario.IdHorarioMedico);
                cmd.Parameters.AddWithValue("@Dia", horario.Dia);
                for (int i = 0; i <= 23; i++)
                {
                    cmd.Parameters.AddWithValue($"@hora_{i}", typeof(Horario_Clinica).GetProperty($"Hora{i}")!.GetValue(horario));
                }
                cmd.Parameters.AddWithValue("@Id_Medico", horario.IdMedico);

                conexion.Open();
                retorno = cmd.ExecuteNonQuery();
            }
            return retorno;
        }

        public List<Horario_Medico> ObtenerHorariosPorMedico(int idMedico)
        {
            List<Horario_Medico> lista = new List<Horario_Medico>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("ObtenerHorariosPorMedico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Clinica", idMedico);

                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Horario_Medico horario = new Horario_Medico
                        {
                            IdHorarioMedico = (int)reader["Id_Horario"],
                            Dia = reader["Dia"].ToString()!,
                            IdMedico = (int)reader["Id_Medico"]
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
