using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;

namespace SpaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpacePortsController : ControllerBase
    {
        private readonly SpaceContext _context;

        public SpacePortsController(SpaceContext context)
        {
            _context = context;
        }

        // GET: api/SpacePorts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpacePort>>> GetSpacePorts()
        {
            return await _context.SpacePorts.OrderBy(i => i.Id).Include(p => p.Parkings).ToListAsync();
        }

        // GET: api/SpacePorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<SpacePort>>> GetSpacePort(int id)
        {
            var spacePort = await _context.SpacePorts.Where(i => i.Id == id).Include(p => p.Parkings).ToListAsync();

            if (spacePort.Count == 0)
            {
                return NotFound();
            }

            return spacePort;
        }

        // PUT: api/SpacePorts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpacePort(int id, SpacePort spacePort)
        {
            if (id != spacePort.Id)
            {
                return BadRequest();
            }

            _context.Entry(spacePort).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpacePortExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/SpacePorts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpacePort>> PostSpacePort(SpacePort spacePort)
        {
            try
            {
                await _context.SpacePorts.AddAsync(spacePort);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSpacePort", new { id = spacePort.Id }, spacePort);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        // DELETE: api/SpacePorts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpacePort(int id)
        {
            var spacePort = await _context.SpacePorts.FindAsync(id);
            if (spacePort == null)
            {
                return NotFound();
            }

            _context.SpacePorts.Remove(spacePort);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpacePortExists(int id)
        {
            return _context.SpacePorts.Any(e => e.Id == id);
        }
    }
}
