namespace TravelApi.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}