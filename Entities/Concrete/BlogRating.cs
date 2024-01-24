namespace Entities.Concrete
{
    public class BlogRating : IEntityBase
    {
        public int ID { get; set; }
        public int BlogID { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }
    }
}
