using System;
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
        public async Task Getting_All_Parkings_With_Non_Existant_SpacePort_Should_Return_Not_Found()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.GetAllParkings("port")).Returns(new List<Parking> { new Parking { Fee = 100, Id = 1, MaxLength = 100, SpacePortId = 1 } });
            var controller = new ParkingsController(database);

            var actionResult = await controller.GetParkings("fakePort");


            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
        [Fact]
        public async Task Getting_All_Parkings_With_No_SpacePort_Specified_Should_Return_Ok()
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
            var parking = new Parking { Id = 1, Fee = 100, MaxLength = 100, Occupied = false, SpacePortId = 1 };
            A.CallTo(() => database.UpdateParking(1, parking));
            var controller = new ParkingsController(database);

            var actionResult = await controller.PutParking(1, parking);


            Assert.IsType<OkResult>(actionResult);
        }
        [Fact]
        public async Task Updating_Parking_With_Wrong_Id_Should_Return_Bad_Request()
        {
            var database = A.Fake<IParkingDataStore>();
            var parking = new Parking { Id = 200, Fee = 100, MaxLength = 100, Occupied = false, SpacePortId = 1 };
            A.CallTo(() => database.UpdateParking(1, parking)).Returns(Task.FromException(new ArgumentException("Id does not match")));
            var controller = new ParkingsController(database);

            var actionResult = await controller.PutParking(1, parking);


            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task Update_Parking_Should_Return_Ok()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.GetParkingById(1)).Returns(new Parking { Fee = 100, MaxLength = 100, SpacePortId = 1 });
            var controller = new ParkingsController(database);

            var actionResult = await controller.GetParking(1);

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task Adding_Parking_Should_Return_CreatedAt()
        {
            var database = A.Fake<IParkingDataStore>();
            var parking = new Parking { Id = 200, Fee = 100, MaxLength = 100, Occupied = false, SpacePortId = 1 };
            A.CallTo(() => database.AddParking(parking)).Returns(parking);
            var controller = new ParkingsController(database);

            var actionResult = await controller.PostParking(parking);


            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }
        [Fact]
        public async Task Deleting_Parking_Should_Return_Ok()
        {
            var database = A.Fake<IParkingDataStore>();
            A.CallTo(() => database.DeleteParking(1)).Returns(Task.CompletedTask);
            var controller = new ParkingsController(database);

            var actionResult = await controller.DeleteParking(1);


            Assert.IsType<OkResult>(actionResult);
        }
    }
}
