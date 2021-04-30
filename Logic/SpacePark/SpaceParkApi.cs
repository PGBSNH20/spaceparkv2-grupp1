using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public class SpaceParkApi
    {
        public static async Task<Parking> GetParking(int? id)
        {
            var client = new RestClient("https://localhost:50839/api/");
            var request = new RestRequest($"Parkings/{id}", DataFormat.Json);
            var response = await client.GetAsync<Parking>(request);
            return response;
        }
    }
}
