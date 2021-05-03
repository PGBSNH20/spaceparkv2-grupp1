using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public ParkingsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/Parkings
        [HttpGet]
        public async Task<ActionResult<SpacePark>> GetParkings()
        {
            var ports = _context.SpacePorts.Include(i => i.Parkings);
            List<SpacePort> tempList = await ports.ToListAsync();

            if (tempList.Count == 0)
                return NoContent();

            return new SpacePark { SpaceParks = tempList };
        }

        // GET: api/Parkings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parking>> GetParking(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);

            if (parking == null)
            {
                return NotFound();
            }

            return parking;
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
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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
