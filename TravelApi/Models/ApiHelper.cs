using System.Threading.Tasks;
using RestSharp;

namespace TravelApi.Models
{
    class ApiHelper
    {
        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"animals/{id}", Method.GET);
            var response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }