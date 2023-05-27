using System.ComponentModel.DataAnnotations;

namespace AcademiaSoft.Models
{
    public class Usuario
    {
        public Usuario() {
            Codigo = "";
        }

        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El Correo electronico es requerido")]
        [StringLength(100, ErrorMessage = "Logitud máxima 100")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email error")]
        [EmailAddress(ErrorMessage = "El Correo electrónico incorrecto")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El Pasword es requerido")]
        [StringLength(100, ErrorMessage = "Logitud máxima 100")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El tipo de usuario es requerido")]
        [StringLength(100, ErrorMessage = "Logitud máxima 100")]
        public string Tipo { get; set; }

        
    }
}
