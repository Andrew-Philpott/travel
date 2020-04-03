using System.Threading.Tasks;
using RestSharp;


namespace TravelClient.Services
{
    class ReviewService
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"reviews", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
        public static async Task Post(string newReview)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"reviews", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newReview);
            var response = await client.ExecuteAsync(request);
        }

        public static async Task Put(int id, string newReview)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newReview);
            var response = await client.ExecuteAsync(request);
        }
        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5005/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
        }
    }
}