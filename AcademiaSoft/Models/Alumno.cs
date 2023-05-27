using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class Alumno
    {
        public Alumno() {
            Codigo = "";
        }

        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Required(ErrorMessage ="Docuemnto es requerido.")]
        [StringLength(8,ErrorMessage ="La Longitud maxima es de 8.")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Nombre es requerido.")]
        [StringLength(50, ErrorMessage = "La Longitud maxima es de 50.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es requerido.")]
        [StringLength(50, ErrorMessage = "La Longitud maxima es de 50.")]
        public string Apellido { get; set; }

        [Display(Name ="Usuario")]
        [Required(ErrorMessage = "Tipo de Usuario es requerido.")]
        [Range(1,10,ErrorMessage ="Debes seleccionar un Usuario.")]
        public int Idusuario { get; set; }
    }
}
