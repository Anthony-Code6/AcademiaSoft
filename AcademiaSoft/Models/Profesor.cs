namespace AcademiaSoft.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Idusuario { get; set; }

        public Profesor()
        {
            Codigo = "";
        }
    }
}
