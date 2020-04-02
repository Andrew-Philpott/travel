
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public virtual ApplicationUser User { get; set; }
        public static List<Destination> GetDestinations()
        {
            var apiCallTask = ApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

            return destinationList;
        }

        public static Destination GetDetails(int id)
        {
            var apiCallTask = ApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Destination destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

            return destination;
        }
        public static List<Destination> Search(string city, string country)
        {
            // Console.WriteLine("In destination.search before " + search);
            var apiCallTask = ApiHelper.Search(city, country);
            var result = apiCallTask.Result;
            Console.WriteLine("In destination.search result" + result);
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Destination> destinationList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());
            Console.WriteLine("destinationList result: " + destinationList);
            return destinationList;
        }
        public static void Post(Destination destination)
        {
            string jsonDestination = JsonConvert.SerializeObject(destination);
            var apiCallTask = ApiHelper.Post(jsonDestination);
        }

        public static void Put(Destination destination)
        {
            string jsonDestination = JsonConvert.SerializeObject(destination);
            var apiCallTask = ApiHelper.Put(destination.DestinationId, jsonDestination);
        }
        public static void Delete(int id)
        {
            var apiCallTask = ApiHelper.Delete(id);
        }
    }
}