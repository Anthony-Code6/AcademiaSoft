using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace AcademiaSoft.Dao
{
    public class CargoDao
    {
        public SqlConnection conn = Conexion.getConexion();

        public List<CargoDao> Listar_Profesor()
        {
            List < CargoDao > list=new List<CargoDao> ();
            return list;
        }
    }
}
