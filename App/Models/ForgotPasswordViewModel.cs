using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class ForgotPasswordViewModel
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string? ConfirmCode { get; set; }
    }
}
