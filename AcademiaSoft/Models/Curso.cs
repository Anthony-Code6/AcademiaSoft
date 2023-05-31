namespace AcademiaSoft.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        //public int Idaula { get; set; }
        public string Descripcion { get; set; }

        public Curso()
        {
            Codigo="";
        }
    }
}
