using Microsoft.AspNetCore.Identity;

namespace Infraestrutura
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime Creation { get; set; }
    }
}
