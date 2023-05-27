namespace AcademiaSoft.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Idalumno { get; set; }
        public int Idaula { get; set; }
        public DateTime Fecha { get; set; }
        public int Idperiodo { get; set; }

        public Matricula()
        {
            Codigo = "";
        }
    }
}
