using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.Model
{
    [Table("USERS")]
    public class Users
    {
        [Key]
        public int ID_USER { get; set; }

        [Required]
        [MaxLength(250)]
        public string NAME_USER { get; set; }

        [Required]
        [Display(Name = "User name / Email")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string EMAIL { get; set; }

        [Required]
        [MaxLength(50)]
        public string PASSWORD_USER { get; set; }

        public string? CELLPHONE { get; set; }

    }
}
