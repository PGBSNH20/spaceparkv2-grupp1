using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceApi.Data;
using SpaceApi.Models;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly IParkingDataStore _parkingData;

        public ParkingsController(IParkingDataStore parkingData)
        {
            _parkingData = parkingData;
        }

        // GET: api/Parkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkings(string portName)
        {
            var s = portName;
            var list = await _parkingData.GetAllParkings(s);
            if (list.Count == 0)
                return NotFound();
            return Ok(list);
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> GetParking(int id)
        {
            var parking = await _parkingData.GetParkingById(id);

            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking);
        }

        // PUT: api/Parkings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParking(int id, Parking parking)
        {
            var status = await _parkingData.UpdateParking(id, parking);

            if (status.Exception != null)
            {
                switch (status.Exception.InnerException.Message)
                {
                    case "Id does not match":
                        return BadRequest();
                    case "Not found":
                        return NotFound();
                }
            }

            if (status.IsCompleted)
                return Ok();

            return NoContent();
        }

        //POST: api/Parkings
        [HttpPost]
        public async Task<ActionResult<Parking>> PostParking(Parking parking)
        {
            var result = await _parkingData.AddParking(parking);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction("GetParking", new { id = parking.Id }, parking);
        }

        // DELETE: api/Parkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking(int id)
        {
            var parking = await _parkingData.DeleteParking(id);
            if (parking == null)
                return NotFound();

            return Ok();
        }
    }
}
