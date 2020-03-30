using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelApi.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public virtual Destination Destination { get; set; }
    }
}