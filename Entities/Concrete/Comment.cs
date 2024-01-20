using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

        //Relationships
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}
