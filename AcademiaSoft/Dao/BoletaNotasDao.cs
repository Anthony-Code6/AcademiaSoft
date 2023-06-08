using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AcademiaSoft.Dao
{
    public class BoletaNotasDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<BoletaNotas> Listar(int ids)
        {
            List<BoletaNotas> list = new List<BoletaNotas>();
            conn.Open();
            using (SqlCommand comando = new SqlCommand("SP_BUSCAR_ALUMNOS_MATRICULADO_BOLETA", conn)) {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add(new SqlParameter("@CODIGO", ids));
                SqlDataReader reader= comando.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new BoletaNotas()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Idmatricula = Convert.ToInt32(reader["idmatricula"]),
                        Idcargo = Convert.ToInt32(reader["idcargo"]),
                        Nota1 = Convert.ToDecimal(reader["nota1"]),
                        Nota2 = Convert.ToDecimal(reader["nota2"]),
                        Nota3 = Convert.ToDecimal(reader["nota3"]),
                        Nota4 = Convert.ToDecimal(reader["nota4"]),
                        Promedio = Convert.ToDecimal(reader["promedio"])
                    });
                }
                conn.Close();
            }
            return list;
        }

        public bool Guardar(BoletaNotas boleta)
        {
            if (Validar_Promedio(boleta)>0)
            {

                return true;
            }

            return false;
        }

        public decimal Validar_Promedio(BoletaNotas notas)
        {
            decimal promedio = 0;
            double operacion= 0;
            if (notas.Nota1 > 0 && notas.Nota2 > 0 && notas.Nota3 > 0 && notas.Nota4 > 0)
            {
                operacion = (double)(notas.Nota1 + notas.Nota2 + notas.Nota3 + notas.Nota4)/4;
            }
            promedio = Convert.ToDecimal(operacion);

            return promedio;
        }

      
       

    }
}
