using Pia_2._0.Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pia_2._0.DAO
{
    public class UsuarioDAO
    {

        public static string HashearContraseña(string contraseña)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16); // 128 bits
            var pbkdf2 = new Rfc2898DeriveBytes(contraseña, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32); // 256 bits

            // Guarda el hash y la sal juntos en base64
            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        public static bool VerificarContrasena(string contraseñaIngresada, string hashGuardado)
        {
            var partes = hashGuardado.Split(':');
            if (partes.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(partes[0]);
            byte[] hashOriginal = Convert.FromBase64String(partes[1]);

            var pbkdf2 = new Rfc2898DeriveBytes(contraseñaIngresada, salt, 100_000, HashAlgorithmName.SHA256);
            byte[] hashIngresado = pbkdf2.GetBytes(32);

            return hashOriginal.SequenceEqual(hashIngresado);
        }



        public static int InsertarUsuario(Usuario usuario)
        {
            int idGenerado = 0;

            string contrahasheada = HashearContraseña(usuario.Contra);

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC InsertarUsuario @Contra, @Rol";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Contra", contrahasheada);
                    comando.Parameters.AddWithValue("@Rol", usuario.Rol);

                    // Devuelve el ID insertado
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        idGenerado = Convert.ToInt32(resultado);
                    }
                }
            }

            return idGenerado;
        }


        public static int ActualizarUsuario(Usuario usuario)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ActualizarUsuario @Id_Usuario = " + usuario.IdUsuario +
                               ", @Contra = '" + usuario.Contra + "', @Rol = '" + usuario.Rol + "';";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static int DarBajaUsuario(int idUsuario)
        {
            int retorno = 0;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC DarBajaUsuario @Id_Usuario = " + idUsuario + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                retorno = comando.ExecuteNonQuery();
            }

            return retorno;
        }


        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "EXEC ObtenerUsuario @Id_Usuario = " + id + ";";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = reader.GetInt32(0);            
                    usuario.Contra = reader.GetString(1);  
                    usuario.Rol = reader.GetString(2);          
                    usuario.EsActivo = reader.GetBoolean(3);   
                }
            }

            return usuario;
        }


        public static List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            {
                string query = "SELECT Id_Usuario, Contra, Rol, Es_activo FROM Usuario;";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = reader.GetInt32(0);                    
                    usuario.Contra = reader.GetString(1);           
                    usuario.Rol = reader.GetString(2);                  
                    usuario.EsActivo = reader.GetBoolean(3);            

                    lista.Add(usuario);
                }
            }

            return lista;
        }

        public static Usuario? Login(int id_usuario, string contrasena)
        {
            using (SqlConnection conexion = BDConexion.ObtenerConexion())
            using (SqlCommand command = new SqlCommand("UsuarioLogin", conexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_usuario", id_usuario);

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string hash = dr["Contra"].ToString();
                        bool esValida = VerificarContrasena(contrasena, hash);

                        if (esValida)
                        {
                            return new Usuario
                            {
                                IdUsuario = (int)dr["Id_Usuario"],
                                Rol = dr["Rol"].ToString(),
                                EsActivo = (bool)dr["Es_activo"],
                                Contra = contrasena
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
