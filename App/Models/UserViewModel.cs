using App.Models.Utils;
using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class UserViewModel : BaseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Profile { get; set; }
        public bool Active { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<User> Itens { get; set; } = new List<User>();
    }
}
