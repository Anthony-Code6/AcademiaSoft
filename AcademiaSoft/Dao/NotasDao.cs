using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class NotasDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<BoletaNotas> ListarMatriculaProfesorAlumno(int idmatricula)
        {
            List<BoletaNotas> list = new List<BoletaNotas>();
            BoletaNotas boleta = null;

            DateTime fecha = DateTime.Today;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_ALUMNOS_MATRICULADO_BOLETA", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", idmatricula));
                cmd.Parameters.Add(new SqlParameter("@fecha", fecha.ToString("d")));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    boleta = new BoletaNotas()
                    {
                        Id = (int)reader["ID"],
                        Idmatricula = (int)reader["IDMATRICULA"],
                        Idcargo = (int)reader["IDCARGO"],
                        Nota1 = (decimal)reader["NOTA1"],
                        Nota2 = (decimal)reader["NOTA2"],
                        Nota3 = (decimal)reader["NOTA3"],
                        Nota4 = (decimal)reader["NOTA1"],
                        Promedio = (decimal)reader["PROMEDIO"]
                    };

                    list.Add(boleta);
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public decimal Validar_Promedio(BoletaNotas notas)
        {
            decimal promedio = 0;
            if (notas.Nota1 > 0)
            {

            }

            return promedio;
        }

      
       

    }
}
