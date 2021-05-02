using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Models;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public class SpaceParkApi
    {
        public static async Task<Parking> GetParking(int id)
        {
            var client = new RestClient("https://localhost:51019/api/");
            var request = new RestRequest($"Parkings/{id}", DataFormat.Json);
            var response = await client.GetAsync<Parking>(request);
            return response;
        }
        public static async Task<SpaceApi.Models.SpacePark> GetAllParkings()
        {
            var client = new RestClient("https://localhost:51019/api/");
            var request = new RestRequest("Parkings/", DataFormat.Json);
            var response = await client.GetAsync<Task<SpaceApi.Models.SpacePark>>(request);
            return response.Result;
        }

    }
}
