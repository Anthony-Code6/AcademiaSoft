using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace AcademiaSoft.Dao
{
    public class CargoProfesorDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<CargoProfesor> Listar()
        {
            List<CargoProfesor> list=new List<CargoProfesor>();
            conn.Open();
            try
            {
                using (SqlCommand cmd=new SqlCommand("SP_LISTAR_CARGO_PROFESOR", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new CargoProfesor()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Idaula = Convert.ToInt32(reader["idaula"]),
                            Idcurso = Convert.ToInt32(reader["idcurso"]),
                            Idprofesor = Convert.ToInt32(reader["idprofesor"]),
                            Idperiodo = Convert.ToInt32(reader["idperiodo"])
                        });
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }
    }
}
