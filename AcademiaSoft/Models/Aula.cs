using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class Aula
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Required(ErrorMessage ="La Descripcion es requerida.")]
        [StringLength(190,ErrorMessage ="La Descripcion tiene una longitud de 190 caracteres")]
        [MaxLength(190,ErrorMessage ="La Descripcion tiene un maximo de 190 caracteres.")]
        public string Descripcion { get; set; }

        public Aula()
        {
            Codigo = "";
        }
    }
}
