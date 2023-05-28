using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using AcademiaSoft.Models;
using System.Collections.Generic;

namespace AcademiaSoft.Dao
{
    public class AulaDao
    {

        public SqlConnection conn=Conexion.getConexion();

       public List<Aula> Listar()
        {
            List<Aula> list=new List<Aula>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_LISTAR_AULA", conn);
                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Aula()
                    {
                        Id = (int)reader["id"],
                        Codigo = (string)reader["codigo"],
                        Descripcion = (string)reader["descripcion"]
                    }) ;
                }
                conn.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list; 
        }

        public Aula Buscar(int id)
        {
            Aula aula = null;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_BUSCAR_AULA", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", id));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        aula = new Aula()
                        {
                            Id = (int)reader["id"],
                            Codigo = (string)reader["codigo"],
                            Descripcion = (string)reader["descripcion"]
                        };
                    }
                }
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return aula;
        }

        public void Guardar(Aula aula)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_REGISTRAR_AULA", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", aula.Id));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", aula.Descripcion));
                cmd.ExecuteNonQuery();
                conn.Close();
            }catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Actualizar(Aula aula)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_AULA", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", aula.Id));
                cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", aula.Descripcion));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
