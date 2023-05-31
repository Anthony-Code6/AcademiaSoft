namespace AcademiaSoft.Models
{
    public class BoletaNotas
    {
        public int Id { get; set; }
        public int Idmatricula { get; set; }
        public int Idcargo { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Promedio { get; set; }
        //public bool Estado { get; set; }
    }
}
