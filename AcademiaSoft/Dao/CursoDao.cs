using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class CursoDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<Curso> ListarCurso()
        {
            List<Curso> list = new List<Curso>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_CURSO", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Curso()
                    {
                        Id = (int)reader["ID"],
                        Codigo = (string)reader["codigo"],
                        Descripcion = (string)reader["descripcion"]
                    });
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
