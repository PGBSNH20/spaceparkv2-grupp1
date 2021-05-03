using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Logic.Models;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public class SpaceParkApi
    {
        public static async Task<Parking> GetParking(int id) // Return the specfied parking lot
        {
            var client = new RestClient("https://localhost/api/");
            var request = new RestRequest($"Parkings/{id}", DataFormat.Json);
            var response = await client.GetAsync<Parking>(request);
            return response;
        }
        public static async Task<List<Parking>> GetAllParkings() // Return a list of all parkings
        {
            var client = new RestClient("https://localhost/api/");
            var request = new RestRequest("Parkings/", DataFormat.Json);
            var response = await client.GetAsync<List<Parking>>(request);
            return response;
        }

    }
}
