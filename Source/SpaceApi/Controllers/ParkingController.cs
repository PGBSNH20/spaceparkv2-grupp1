using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"Park 1", "Park 2", "Park 3"}; // Replace this with call to dataAccess layer
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Value is " + id;
        }
    }
}
