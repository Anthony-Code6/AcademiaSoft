using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using AcademiaSoft.Models;

namespace AcademiaSoft.Dao
{
    public class PeriodoDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public void Guardar(Periodo periodo)
        {
            conn.Open();
            using (SqlCommand comando=new SqlCommand("SP_REGISTRAR_PERIODO", conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID", periodo.Id));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE1", periodo.Trimestre_1));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE2", periodo.Trimestre_2));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE3", periodo.Trimestre_3));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE4", periodo.Trimestre_4));
                comando.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Actualizar(Periodo periodo)
        {
            conn.Open();
            using (SqlCommand comando = new SqlCommand("SP_ACTUALIZAR_PERIODO", conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@ID", periodo.Id));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE1", periodo.Trimestre_1));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE2", periodo.Trimestre_2));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE3", periodo.Trimestre_3));
                comando.Parameters.Add(new SqlParameter("@TRIMESTRE4", periodo.Trimestre_4));
                comando.ExecuteNonQuery();
            }
            conn.Close();
        }

        public string Eliminar(int id)
        {
            string mensaje = null;
            try
            {
                conn.Open();
                SqlCommand comando = new SqlCommand("SP_ELIMINAR_PERIODO", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@CODIGO", id));

                // mensaje = (string)comando.Parameters["@ERROR"].Value;
                //comando.ExecuteNonQuery();
            
                SqlDataReader reader= comando.ExecuteReader();
                while (reader.Read())
                {
                    mensaje = (string)reader["Error"];
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al Eliminar"+ex.ToString());
            }
            return mensaje;
        }

        public Periodo Buscar(int id)
        {
            Periodo periodo = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_PERIODO", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", id));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        periodo = new Periodo()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Codigo = (string)reader["codigo"],
                            Trimestre_1 = (DateTime)reader["fectrimestre1"],
                            Trimestre_2 = (DateTime)reader["fectrimestre2"],
                            Trimestre_3 = (DateTime)reader["fectrimestre3"],
                            Trimestre_4 = (DateTime)reader["fectrimestre4"]
                        };
                    }
                }
                conn.Close();
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
            }

            return periodo;
        }

        public List<Periodo> Listar()
        {
            List<Periodo> list=new List<Periodo>();
            conn.Open();
            using (SqlCommand comando=new SqlCommand("SP_LISTAR_PERIODO", conn))
            {
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader= comando.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Periodo() {
                        Id = Convert.ToInt32(reader["id"]),
                        Codigo = (string)reader["codigo"],
                        Trimestre_1 = (DateTime)reader["fectrimestre1"],
                        Trimestre_2 = (DateTime)reader["fectrimestre2"],
                        Trimestre_3 = (DateTime)reader["fectrimestre3"],
                        Trimestre_4 = (DateTime)reader["fectrimestre4"]
                });
                }
                conn.Close();
            }
            return list;
        }
    }
}
