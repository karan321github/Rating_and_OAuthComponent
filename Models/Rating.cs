namespace GoogleAuth.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Value { get; set; }
       
        public virtual Product Product { get; set; }
    }
}
