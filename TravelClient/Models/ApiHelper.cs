using System.Threading.Tasks;
using RestSharp;
namespace TravelApi.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("https://localhost:5005/api");
            RestRequest request = new RestRequest($"destinations", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
        public static async Task Post(string newDestination)
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"destinations", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newDestination);
            var response = await client.ExecuteAsync(request);
        }

        public static async Task Put(int id, string newAnimal)
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newAnimal);
            var response = await client.ExecuteAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"destinations/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
        }
    }
}