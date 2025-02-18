using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ChangePasswordViewModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
