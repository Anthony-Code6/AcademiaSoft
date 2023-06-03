using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class MatriculaDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<Matricula> ListarAlumnoMatricula()
        {
            List<Matricula> list = new List<Matricula>();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SP_LISTAR_MATRICULA", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Matricula()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Codigo = (string)reader["codigo"],
                        Idalumno = (int)reader["idalumno"],
                        Idaula = (int)reader["idaula"],
                        Fecha = Convert.ToDateTime(reader["fecha"])
                    }); 
                }
                conn.Close();
            }
            return list;
        }
    }
}
