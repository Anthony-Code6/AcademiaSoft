using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class BoletaNotas
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Matricula")]
        [Required(ErrorMessage = "La Matricula es requerida.")]
        [Range(1,10,ErrorMessage ="Debes seleccionar una matricula")]
        public int Idmatricula { get; set; }

        [Display(Name ="Cargo")]
        [Required(ErrorMessage = "El Cargo es requerida.")]
        [Range(1, 10, ErrorMessage = "")]
        public int Idcargo { get; set; }

        [Required(ErrorMessage ="La Primera nota es requerida.")]
        [RegularExpression("(^[0-20]+$)", ErrorMessage = "Solo se permiten números")]
        public decimal? Nota1 { get; set; }

        [Required(ErrorMessage = "La Segunda nota es requerida.")]
        [RegularExpression("(^[0-20]+$)", ErrorMessage = "Solo se permiten números")]
        public decimal? Nota2 { get; set; }

        [Required(ErrorMessage = "La Tercera nota es requerida.")]
        [RegularExpression("(^[0-20]+$)", ErrorMessage = "Solo se permiten números")]
        public decimal? Nota3 { get; set; }

        [Required(ErrorMessage = "La Cuarta nota es requerida.")]
        [RegularExpression("(^[0-20]+$)", ErrorMessage = "Solo se permiten números")]
        public decimal? Nota4 { get; set; }
        
        public decimal? Promedio { get; set; }

        public BoletaNotas()
        {
            Promedio = 0;
        }
    }
}
