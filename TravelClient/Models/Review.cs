using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
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

        // public static List<Review> GetReviews()
        // {
        //     var apiCallTask = ApiHelper.GetAll();
        //     var result = apiCallTask.Result;

        //     JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
        //     List<Animal> animalList = JsonConvert.DeserializeObject<List<Animal>>(jsonResponse.ToString());

        //     return animalList;
        // }
    }


}