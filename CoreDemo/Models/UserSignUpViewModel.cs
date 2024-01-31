using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Please , write your name and surname.")]
        public string nameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please , write password.")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please , write your email address.")]
        public string Mail { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please, write your user name.")]
        public string UserName { get; set; }
    }
}
