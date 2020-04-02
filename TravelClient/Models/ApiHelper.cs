using System.Threading.Tasks;
using RestSharp;
using System;

namespace TravelClient.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<string> Search(string city, string country)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/search?city={city}&country={country}", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            Console.WriteLine("In apihelper search, response value: " + response);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.GET);
            // request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
        public static async Task Post(string newDestination)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newDestination);
            var response = await client.ExecuteAsync(request);
        }

        public static async Task Put(int id, string newDestination)
        {
            Console.WriteLine("Put id: " + id);
            Console.WriteLine("Put id: " + newDestination);
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newDestination);
            var response = await client.ExecuteAsync(request);
        }
        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
        }

        public static async Task<string> GetByReviews()
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/reviews", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
        public static async Task<string> GetByRatings()
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations/ratings", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}