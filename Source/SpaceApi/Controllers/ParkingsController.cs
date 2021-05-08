using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Data;
using SpaceApi.Models;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly SpaceContext _context;
        private readonly IParkingDataStore _parkingData;

        public ParkingsController(IParkingDataStore parkingData)
        {
            _parkingData = parkingData;
        }

        // GET: api/Parkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkings(string portName)
        {
            var list = _parkingData.GetAllParkings(portName);
            if (list.Result.Count == 0)
                return NotFound();
            return Ok(list.Result);
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> GetParking(int id)
        {
            var parking = _parkingData.GetParkingById(id);

            if (parking == null)
            {
                return NotFound();
            }

            return Ok(parking.Result);
        }

        // PUT: api/Parkings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParking(int id, Parking parking)
        {
            if (id != parking.Id)
            {
                return BadRequest();
            }

            _context.Entry(parking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkingExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        //POST: api/Parkings
        [HttpPost]
        public async Task<ActionResult<Parking>> PostParking(Parking parking)
        {
            try
            {
                await _context.Parkings.AddAsync(parking);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetParking", new { id = parking.Id }, parking);
            }
            catch
            {
                return BadRequest();
            }

        }

        // DELETE: api/Parkings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParking(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }
    }
}
