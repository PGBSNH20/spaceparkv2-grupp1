using System.Collections.Generic;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SpaceApi.Controllers;
using SpaceApi.Data;
using SpaceApi.Models;
using Xunit;

namespace SpaceApiTests
{
    public class ParkingControllerTests
    {
        [Fact]
        public async Task Getting_All_With_Non_Existant_SpacePort_Should_Return_Not_Found()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.GetAllParkings("port")).Returns(new List<Parking> { new Parking { Fee = 100, Id = 1, MaxLength = 100, SpacePortId = 1 } });
            var controller = new ParkingsController(database);

            var actionResult = await controller.GetParkings("fakePort");


            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
        [Fact]
        public async Task Getting_All_With_Existant_SpacePort_Should_Ok()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.GetAllParkings(null)).Returns(new List<Parking> { new Parking { Fee = 100, Id = 1, MaxLength = 100, SpacePortId = 1 } });
            var controller = new ParkingsController(database);

            var actionResult = await controller.GetParkings(null);


            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task Getting_Parkings_With_Id_Should_Return_Ok()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.GetParkingById(1)).Returns(new Parking {Fee = 100, MaxLength = 100, SpacePortId = 1 });
            var controller = new ParkingsController(database);

            var actionResult = await controller.GetParking(1);


            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
    }
}
