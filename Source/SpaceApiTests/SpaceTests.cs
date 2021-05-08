using System;
using Logic.SpacePark;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SpaceApi.Controllers;
using SpaceApi.Models;
using Xunit;
using static RestSharp.ResponseStatus;

namespace SpaceApiTests
{
    public class SpaceTests
    {
        [Fact]
        public void Getting_All_Parkings_Should_Return_Four()
        {
            ISpaceParkApi api = new SpaceParkApiStub();

            var list = api.GetAllParkings();

            Assert.Equal(4, list.Result.Count);
        }
        [Fact]
        public void Updating_Parking_Should_Return_Response_Completed()
        {
            ISpaceParkApi api = new SpaceParkApiStub();

            var parking = new Parking
            {
                Id = 1,
                Fee = 100,
                MaxLength = 100,
                Occupied = true,
                ParkedBy = "Person",
                ShipName = "Invector",
                SpacePortId = 1
            };

            var response = api.Park(parking);

            Assert.Equal(Completed, response.ResponseStatus);
        }
    }
}