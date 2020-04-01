
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelApi.Models
{
    public class Destination
    {
        public Destination()
        {
            this.Reviews = new HashSet<Review>();
        }
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}