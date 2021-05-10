using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SpaceApi.Controllers;
using SpaceApi.Data;
using SpaceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpaceApiTests
{
    public class SpacePortControllerTests
    {
        [Fact]
        public async Task Getting_All_SpacePorts_Should_Return_Ok()
        {
            var database = A.Fake<ISpacePortDataStore>();
            A.CallTo(() => database.GetAllSpacePorts()).Returns(new List<SpacePort> { new SpacePort { Id = 1, PortName = "Test" } });
            var controller = new SpacePortsController(database);

            var actionResult = await controller.GetSpacePorts();


            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task Getting_SpacePort_With_Id_Should_Return_Ok()
        {
            var database = A.Fake<ISpacePortDataStore>();
            var spacePort = new SpacePort { Id = 1, PortName = "TestPort" };
            var controller = new SpacePortsController(database);

            A.CallTo(() => database.GetSpacePortById(1)).Returns(spacePort);
            var actionResult = await controller.GetSpacePort(1);


            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
        [Fact]
        public async Task Updating_SpacePort_With_Wrong_Id_Should_Return_Bad_Request()
        {
            var database = A.Fake<ISpacePortDataStore>();
            var spacePort = new SpacePort { Id = 100, PortName = "TestPort" };
            A.CallTo(() => database.UpdateSpacePort(1, spacePort)).Returns(Task.FromException(new ArgumentException("Id does not match")));
            var controller = new SpacePortsController(database);

            var actionResult = await controller.PutSpacePort(1, spacePort);


            Assert.IsType<BadRequestResult>(actionResult);
        }
        [Fact]
        public async Task Update_SpacePort_Should_Return_Ok()
        {
            var database = A.Fake<ISpacePortDataStore>();
            var spacePort = new SpacePort { Id = 1, PortName = "TestPort2" };
            var controller = new SpacePortsController(database);

            A.CallTo(() => database.UpdateSpacePort(1, spacePort));
            var actionResult = await controller.PutSpacePort(1, spacePort);

            Assert.IsType<OkResult>(actionResult);
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
        public async Task Deleting_SpacePort_Should_Return_Ok()
        {
            var database = A.Fake<ISpacePortDataStore>();
            A.CallTo(() => database.DeleteSpacePort(1)).Returns(Task.CompletedTask);
            var controller = new SpacePortsController(database);

            var actionResult = await controller.DeleteSpacePort(1);


            Assert.IsType<OkResult>(actionResult);
        }
    }
}

