using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Notification : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string NotificationColor { get; set; }
    }
}
