using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class Periodo
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
 
        [DataType(DataType.Date,ErrorMessage ="El Formato es Incorrecto")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage = "La Fecha del Primer periodo es requeridad.")]
        public DateTime Trimestre_1 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El Formato es Incorrecto")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La Fecha del Segundo periodo es requeridad.")]
        public DateTime Trimestre_2 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El Formato es Incorrecto")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La Fecha del Tercer periodo es requeridad.")]
        public DateTime Trimestre_3 { get; set; }

        [DataType(DataType.Date, ErrorMessage = "El Formato es Incorrecto")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "La Fecha del Cuarto periodo es requeridad.")]
        public DateTime Trimestre_4 { get; set; }

        public Periodo()
        {
            Codigo = "";
        }
    }
}
