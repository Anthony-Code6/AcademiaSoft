using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class ProfesorDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<Profesor> ListarProfesor()
        {
            List<Profesor> list = new List<Profesor>();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SP_LISTAR_PROFESOR", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Profesor()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Codigo = (string)reader["codigo"],
                        Documento = (string)reader["documento"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Idusuario = Convert.ToInt32(reader["idusuario"])
                    });
                }
                conn.Close();
            }
            return list;
        }
    }
}
