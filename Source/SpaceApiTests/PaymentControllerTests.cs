using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SpaceApi.Controllers;
using SpaceApi.Data;
using SpaceApi.Models;
using SpaceApi.SWAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpaceApiTests
{
    public class PaymentControllerTests
    {
        [Fact]
        public async Task Adding_Payment_Should_Return_CreatedAt()
        {
            var database = A.Fake<IPaymentsDataStore>();
            var payment = new Payment { Amount = 100, Id = 1, User = "PErson", PayDate = DateTime.Now };
            A.CallTo(() => database.AddPayment(payment)).Returns(payment);
            var controller = new PaymentsController(database);

            var actionResult = await controller.PostPayment(payment);


            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }
    }
}
