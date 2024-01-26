using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Message2 : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public int? Sender { get; set; }
        public int? Receiver { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
