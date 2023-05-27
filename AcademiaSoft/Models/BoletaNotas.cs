namespace AcademiaSoft.Models
{
    public class BoletaNotas
    {
        public int Idcurso { get; set; }
        public int Idprofesor { get; set; }
        public int Idalumno { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }
        public decimal Nota4 { get; set; }
        public decimal Promedio { get; set; }
        public bool Estado { get; set; }
    }
}
