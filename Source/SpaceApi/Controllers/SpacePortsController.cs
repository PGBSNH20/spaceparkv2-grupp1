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
    public class SpacePortsController : ControllerBase
    {
        private readonly ISpacePortDataStore _spacePortData;

        public SpacePortsController(ISpacePortDataStore spacePortData)
        {
            _spacePortData = spacePortData;
        }

        // GET: api/SpacePorts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpacePort>>> GetSpacePorts()
        {
            return Ok(await _spacePortData.GetAllSpacePorts());
            //return await _context.SpacePorts.OrderBy(i => i.Id).Include(p => p.Parkings).ToListAsync();
        }

        // GET: api/SpacePorts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpacePort>> GetSpacePort(int id)
        {
            var spacePort = await _spacePortData.GetSpacePortById(id);

            if (spacePort == null)
            {
                return NotFound();
            }

            return Ok(spacePort);
        }

        // PUT: api/SpacePorts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpacePort(int id, SpacePort spacePort)
        {
            var status = await _spacePortData.UpdateSpacePort(id, spacePort);

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

        // POST: api/SpacePorts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpacePort>> PostSpacePort(SpacePort spacePort)
        {
            var result = await _spacePortData.AddSpacePort(spacePort);
            if (result == null)
                return BadRequest();
            return CreatedAtAction("PostSpacePort", new { id = spacePort.Id }, spacePort);
        }


        // DELETE: api/SpacePorts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpacePort(int id)
        {
            var spacePort = await _spacePortData.DeleteSpacePort(id);
            if (spacePort == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
