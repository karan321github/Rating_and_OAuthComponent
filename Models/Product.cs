namespace GoogleAuth.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
