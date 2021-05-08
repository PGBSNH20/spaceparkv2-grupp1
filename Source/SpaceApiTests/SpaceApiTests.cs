using System;
using System.Collections.Generic;
using System.Linq;
using Logic.SpacePark;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SpaceApi.Controllers;
using SpaceApi.Models;
using Xunit;
using static RestSharp.ResponseStatus;

namespace SpaceApiTests
{
    public class SpaceApiTests
    {
        [Fact]
        public void GetPayments_Luke_Skywalker_Should_Return_Luke_Amoúnt100()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new PaymentsController(context);
            //Act
            var result = controller.GetPayments("Luke Skywalker");

            //Assert
            Assert.Equal("Luke Skywalker", result[0].User);
            Assert.Equal(100, result[0].Amount);
        }
        [Fact]
        public void PostPayments_Should_Save_To_DB_Number_Three()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new PaymentsController(context);
            Payment testPayment = new Payment { Amount = 200, User = "Leia Organa"};
            //Act
            var result = controller.PostPayment(testPayment);
            testPayment.Id = 3;
            //Assert
            Assert.Equal(testPayment, context.Payments.Single(p=>p.Id == 3));
        }
        [Fact]
        public void GetParkings_DarthPort_Should_Return_Two_Parkings()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new ParkingsController(context);
            List<Parking> actual = new List<Parking> {
                new Parking() { Id = 1, SpacePortId = 1, Fee = 10, MaxLength = 50, Occupied = true, ParkedBy ="Luke Skywalker", ShipName = "X-wing" },
                new Parking() { Id = 2, SpacePortId = 1, Fee = 50, MaxLength = 100, Occupied = false } };
            //Act
            var result = controller.GetParkings("Darth Port").Result.Value;
            //Assert.
            Assert.Equal(actual.Count, result.Count());
        }
        [Fact]
        public void GetSpaceports_Should_Return_TwoSpaceports()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new SpacePortsController(context);
            List<SpacePort> actual = new List<SpacePort> {
                new SpacePort { Id = 1, PortName = "Darth Port" },
                new SpacePort { Id = 2, PortName = "Port 2" } };
        
            //Act
            var result = controller.GetSpacePorts().Result.Value;
            //Assert.
            Assert.Equal(actual.Count, result.Count());
        }
        [Fact]
        public void GetAvailableStarships_Luke_Skywalker_Should_Return_One_Ship()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new SpaceshipsController(context);

            //Act
            var result = controller.GetAvailableStarships("Luke Skywalker");
            //Assert.
            Assert.Single(result);
        }
        [Fact]
        public void GetAvailableStarships_QWERTY_Should_Return_Null()
        {
            //Arrange
            using var db = new TestDatabase();
            using var context = db.CreateContext();
            var controller = new SpaceshipsController(context);

            //Act
            var result = controller.GetAvailableStarships("qwerty");
            //Assert.
            Assert.Null(result);
        }
    }
}