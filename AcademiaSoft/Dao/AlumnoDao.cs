using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace AcademiaSoft.Dao
{
    public class AlumnoDao
    {
        // VARIABLE DE CONEXION
        public SqlConnection conn = Conexion.getConexion();
        
        
        public void Guardar(Alumno alumno)
        {
            try
            {
                string sql_procedure = "SP_REGISTRAR_ALUMNO";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", alumno.Id));
                cmd.Parameters.Add(new SqlParameter("@DOCUMENTO", alumno.Documento));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", alumno.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDO", alumno.Apellido));
                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", alumno.Idusuario));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex) { 
                Console.WriteLine(ex.Message);
            }
        }

        public void Actualizar(Alumno alumno)
        {
            try
            {
                string sql_procedure = "SP_ACTUALIZAR_ALUMNO";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ID", alumno.Id));
                cmd.Parameters.Add(new SqlParameter("@DOCUMENTO", alumno.Documento));
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", alumno.Nombre));
                cmd.Parameters.Add(new SqlParameter("@APELLIDO", alumno.Apellido));
                cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", alumno.Idusuario));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Eliminar(int codigo_alumno)
        {
            try
            {
                string sql_procedure = "SP_BORRAR_ALUMNO";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo_alumno));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Alumno Buscar(int id)
        {
            Alumno alumno = null;
            try
            {
                string sql_procedure = "SP_BUSCAR_ALUMNO";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql_procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CODIGO", id));
                
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        alumno = new Alumno()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Codigo = (string)reader["codigo"],
                            Documento = (string)reader["documento"],
                            Nombre = (string)reader["nombre"],
                            Apellido = (string)reader["apellido"],
                            Idusuario = Convert.ToInt32(reader["idusuario"])
                        };
                    }
                }
                conn.Close();
            }
            catch (SqlException error)
            {
                Console.WriteLine(error.Message);
            }

            return alumno;
        }

        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> list = new List<Alumno>();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SP_LISTAR_ALUMNO", conn))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Alumno()
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
