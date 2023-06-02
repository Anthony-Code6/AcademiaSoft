using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class CursoProfesor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="")]
        [Range(1,100,ErrorMessage ="")]
        public int Idaula { get; set; }

        [Required(ErrorMessage = "")]
        [Range(1, 100, ErrorMessage = "")]
        public int Idcurso { get; set; }

        [Required(ErrorMessage = "")]
        [Range(1, 100, ErrorMessage = "")]
        public int Idprofesor { get; set; }

        [Required(ErrorMessage = "")]
        [Range(1, 100, ErrorMessage = "")]
        public int Idperiodo { get; set; }
    }
}
