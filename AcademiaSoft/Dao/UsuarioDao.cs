using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class UsuarioDao
    {
        public SqlConnection conn = Conexion.getConexion();
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> list = new List<Usuario>();
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_LISTAR_USUARIO", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Usuario()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Codigo = reader["codigo"].ToString(),
                        Password = reader["password"].ToString(),
                        Tipo = reader["tipo"].ToString(),
                        Correo = reader["email"].ToString()
                    });
                }
                conn.Close();
            }
            return list;
        }

        //SP_BUSCAR_USUARIO
        public Usuario Buscar(int id)
        {
            Usuario usuario = null;
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_BUSCAR_USUARIO", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuario=new Usuario()
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Codigo = reader["codigo"].ToString(),
                        Password = reader["password"].ToString(),
                        Tipo = reader["tipo"].ToString(),
                        Correo = reader["email"].ToString()
                    };
                }
                conn.Close();
            }
            return usuario;
        }

        public void Guardar(Usuario usuario)
        {
            conn.Open();
            using (SqlCommand cmd=new SqlCommand("SP_REGISTRAR_USUARIO", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", usuario.Id));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", usuario.Correo));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", usuario.Password));
                cmd.Parameters.Add(new SqlParameter("@TIPO", usuario.Tipo));
                cmd.ExecuteNonQuery();

                conn.Close() ;
            }
        }

        public void Actualizar(Usuario usuario)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_USUARIO", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", usuario.Id));
                cmd.Parameters.Add(new SqlParameter("@EMAIL", usuario.Correo));
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", usuario.Password));
                cmd.Parameters.Add(new SqlParameter("@TIPO", usuario.Tipo));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        public void Eliminar(int id)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SP_ELIMINAR_USUARIO", conn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", id));
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }
    }
}
