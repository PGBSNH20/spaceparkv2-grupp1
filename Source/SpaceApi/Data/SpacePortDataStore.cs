using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Data
{
    public class SpacePortDataStore : ISpacePortDataStore
    {
        private readonly SpaceContext _context;

        public SpacePortDataStore(SpaceContext context)
        {
            _context = context;
        }
        public async Task<List<SpacePort>> GetAllSpacePorts()
        {
            return await _context.SpacePorts.OrderBy(i => i.Id).ToListAsync();
        }
        public async Task<IEnumerable<SpacePort>> GetSpacePortById(int id)
        {
            return await _context.SpacePorts.Where(i => i.Id == id).Include(p => p.Parkings).ToListAsync();
        }
        public async Task<Task> UpdateSpacePort(int id, SpacePort spacePort)
        {
            if (id != spacePort.Id)
            {
                return Task.FromException(new ArgumentException("Id does not match"));
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
                    return Task.FromException(new ArgumentException("Not found"));
                }

                throw;
            }
            return Task.CompletedTask;
        }
        public async Task<SpacePort> AddSpacePort(SpacePort spacePort)
        {

            try
            {
                await _context.SpacePorts.AddAsync(spacePort);
                await _context.SaveChangesAsync();

                return spacePort;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Task> DeleteParking(int id)
        {
            var spacePort = await _context.SpacePorts.FindAsync(id);
            
            if (spacePort == null)
                return null;

            _context.SpacePorts.Remove(spacePort);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
        private bool SpacePortExists(int id)
        {
            return _context.SpacePorts.Any(e => e.Id == id);
        }
    }
}
