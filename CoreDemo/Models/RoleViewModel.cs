using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Please , entry Role name!")]
        public string Name { get; set; }
    }
}
