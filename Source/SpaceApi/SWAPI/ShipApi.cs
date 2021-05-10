using RestSharp;
using SpaceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.SWAPI
{
    public class ShipApi
    {
        public async Task<Starship> GetStarships(string address) // Get all starships from API
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("starships/" + address, DataFormat.Json);
            var response = await client.GetAsync<Starship>(request);
            return response;
        }
        private static async Task<Starship> CreateTask(string address) // Create tasks to run each page of API request async
        {
            var shipApi = new ShipApi();
            return await Task.Run(() => shipApi.GetStarships(address));
        }
        public static List<Starship> GetPersonsStarshipsAvailableForParking(Results person, SpaceContext context)
        {
            List<string> shipsAddresses = person.Starships; // List the users starship URLs
            if (shipsAddresses.Count != 0)
            {
                IEnumerable<string> addressNumber = GetShipNumber(shipsAddresses); // Extract the ship number from URL.
                List<Starship> ownShips = new();
                foreach (string s in addressNumber)
                {
                    ownShips.Add(CreateTask(s).Result); // Run API request to get each ship and put in list
                }
                ownShips = RemoveParkedShips(ownShips, context); // Remove ships if they are already parked in the database.
                return ownShips;
            }
            return new List<Starship> { };
        }

        private static List<Starship> RemoveParkedShips(List<Starship> ownShips, SpaceContext context) // Remove ships if they are already parked in the database.
        {
            var parkedShips = context.Parkings.Where(p => p.Occupied).ToList();
            for (int i = 0; i < parkedShips.Count(); i++)
            {
                var name = parkedShips[i].ShipName;
                if (ownShips.Any(n => n.Name == name))
                {
                    var index = ownShips.First(s => s.Name == name);
                    ownShips.Remove(index);
                }
            }
            return ownShips;
        }
        public static IEnumerable<string> GetShipNumber(IEnumerable<string> shipsAddresses) // Extract the ship number from URL.
        {
            return from s in shipsAddresses let index = s.TrimEnd('/').LastIndexOf('/') select s.Substring(index + 1);
        }
    }
}
