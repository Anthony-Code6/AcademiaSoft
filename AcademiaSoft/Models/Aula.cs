namespace AcademiaSoft.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Aula()
        {
            Codigo = "";
        }
    }
}
