using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Message : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
