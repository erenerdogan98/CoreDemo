using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
    }
}
