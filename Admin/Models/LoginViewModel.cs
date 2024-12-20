using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
