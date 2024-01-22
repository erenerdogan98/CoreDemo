using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NewsLetter : IEntityBase
    {
        [Key]
        public int ID { get; set; }
        public string Mail { get; set; }
        public string MailStatus { get; set; }
    }
}
