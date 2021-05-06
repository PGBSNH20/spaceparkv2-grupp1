using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public class SpaceParkApi
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
        public async Task<List<SpaceApi.Models.Starship>> GetPersonsStarshipsAvailableForParking(string personName)
        {
            var client = new RestClient("https://localhost/api/");
            client.AddDefaultHeader("apikey", "secret1234");
            var request = new RestRequest($"Spaceships?personName={personName}", DataFormat.Json);
            var response = await client.GetAsync<List<SpaceApi.Models.Starship>>(request);
            return response;
        }
    }
}
