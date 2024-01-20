using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Category : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        // Relationships
        public List<Blog> Blogs { get; set; }
    }
}
