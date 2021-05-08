using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly ISpaceContext _context;

        public ParkingsController(ISpaceContext context)
        {
            _context = context;
        }

        // GET: api/Parkings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parking>>> GetParkings(string portName)
        {
            if (portName != null)
            {
                var list = await _context.SpacePorts.Where(p => p.PortName == portName).Include(i => i.Parkings)
                    .SelectMany(t => t.Parkings).ToListAsync();
                if (list.Count == 0)
                    return NotFound();
                return list;
            }
            return await _context.Parkings.ToListAsync();
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
            DbContext dBContext = (DbContext)_context;
            dBContext.Entry(parking).State = EntityState.Modified;

            try
            {
                await dBContext.SaveChangesAsync();
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
                DbContext dBContext = (DbContext)_context;
                await dBContext.SaveChangesAsync();

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
            DbContext dBContext = (DbContext)_context;
            await dBContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }
    }
}
