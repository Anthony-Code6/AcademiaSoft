using Microsoft.Data.SqlClient;

namespace AcademiaSoft.Services
{
    public class Conexion
    {
        
        // CONEXION A LA BASE DE DATOS

        public static SqlConnection getConexion()
        {
            // REFERENCIA DE LA CADENA DE CONEXION A SQL SERVER
            string conexion = "Data Source=LAPTOP-NGE2BIFI;Initial Catalog=Academia_Soft;Integrated Security=True;TrustServerCertificate=True;"; 
            SqlConnection con = new SqlConnection(conexion);
            return con;
        }

    }
}
