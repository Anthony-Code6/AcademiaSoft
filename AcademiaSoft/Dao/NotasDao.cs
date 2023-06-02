using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class NotasDao
    {
        public SqlConnection conn = Conexion.getConexion();


        public BoletaNotas BuscarMatricula(int idmatricula)
        {
            BoletaNotas boleta = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_BOLETAS",conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IDCARGO", idmatricula));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
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
                    }
                }
                conn.Close();
            }catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return boleta;
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
