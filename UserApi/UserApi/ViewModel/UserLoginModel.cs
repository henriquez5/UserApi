using System.ComponentModel.DataAnnotations;

namespace UserApi.ViewModel
{
    public class UserLoginModel
    {
        [Required, MaxLength(250)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }
    }
}
