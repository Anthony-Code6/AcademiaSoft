using AcademiaSoft.Models;
using AcademiaSoft.Services;
using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Dao
{
    public class NotasDao
    {
        public SqlConnection conn = Conexion.getConexion();


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
