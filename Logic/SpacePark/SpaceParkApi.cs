using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public class SpaceParkApi : ISpaceParkApi
    {
        public async Task<Parking> GetParkingById(int id) // Return the specfied parking lot
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest($"parkings/{id}", DataFormat.Json);
            var response = await client.GetAsync<Parking>(request);
            return response;
        }
        public async Task<List<Parking>> GetParkingByPortName(string portName) // Return the specfied parking lot
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest($"parkings?portname={portName}", DataFormat.Json);
            var response = await client.GetAsync<List<Parking>>(request);
            return response;
        }
        public async Task<List<Parking>> GetAllParkings() // Return a list of all parkings
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("parkings/", DataFormat.Json);
            var response = await client.GetAsync<List<Parking>>(request);
            return response;
        }
        public async Task<List<SpacePort>> GetAllSpacePorts()
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("spaceports/", DataFormat.Json);
            var response = await client.GetAsync<List<SpacePort>>(request);
            return response;
        }
        public IRestResponse Park(Parking parking) // Update existing parking - Used for parking a ship, can also be used to remove a ship
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("parkings/" + parking.Id, Method.PUT);
            request.AddJsonBody(parking);
            return client.Execute(request);
        }
        public IRestResponse AddSpacePort(SpacePort spacePort)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("spaceports/", Method.POST);
            request.AddJsonBody(spacePort);
            return client.Execute(request);
        }
        public IRestResponse RemoveSpacePort(SpacePort spacePort)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("spaceports/" + spacePort.Id, Method.DELETE);
            return client.Execute(request);
        }
        public IRestResponse AddParking(Parking parking)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("parkings/", Method.POST);
            request.AddJsonBody(parking);
            return client.Execute(request);
        }
        public IRestResponse RemoveParking(Parking parking)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("parkings/" + parking.Id, Method.DELETE);
            return client.Execute(request);
        }
        public async Task<List<Starship>> GetPersonsStarshipsAvailableForParking(string personName) // Return a list of spaceships that belong to personName and are not yet parked. Return null if personName isn't a part of StarWars movies.  
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest($"Spaceships?personName={personName}", DataFormat.Json);
            var response = await client.GetAsync<List<Starship>>(request);
            return response;
        }
        public IRestResponse AddPay(Payment payment)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest("payments/", Method.POST);
            request.AddJsonBody(payment);
            return client.Execute(request);
        }
        public async Task<List<Payment>> GetReceipts(string personName)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest($"payments?personName={personName}", DataFormat.Json);
            var response = await client.GetAsync<List<Payment>>(request);
            return response;
        }
    }
}
