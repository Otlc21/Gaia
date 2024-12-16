using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }
    }
}
