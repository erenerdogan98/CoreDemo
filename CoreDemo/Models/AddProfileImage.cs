namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
