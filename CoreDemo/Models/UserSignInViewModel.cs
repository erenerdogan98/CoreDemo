using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Please , write your User Name!")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Please , write your password")]
        public string password { get; set; }
    }
}
