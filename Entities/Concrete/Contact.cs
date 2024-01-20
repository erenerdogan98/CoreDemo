using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
