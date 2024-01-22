using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Writer : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string About  { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        // relation with Blog
        public List<Blog> Blogs { get; set; }
    }
}
