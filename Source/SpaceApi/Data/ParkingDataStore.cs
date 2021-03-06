using Microsoft.EntityFrameworkCore;
using SpaceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace SpaceApi.Data
{
    public class ParkingDataStore : IParkingDataStore
    {
        private readonly SpaceContext _context;

        public ParkingDataStore(SpaceContext context)
        {
            _context = context;
        }
        public async Task<List<Parking>> GetAllParkings(string portName)
        {
            if (portName != null)
            {
                var correctedName = portName.Trim('"', ' '); // Check name for trailing characters

                if (_context.SpacePorts.Any(p => p.PortName == correctedName))
                {
                    var spacePort = _context.SpacePorts.First(p => p.PortName == correctedName).Id;
                    return await _context.Parkings.Where(p => p.SpacePortId == spacePort).ToListAsync();
                }

                return new List<Parking>(); // Return empty list if nothing is found
            }
            return await _context.Parkings.ToListAsync(); // If no name is given return all
        }
        public async Task<Parking> GetParkingById(int id)
        {
            return await _context.Parkings.FindAsync(id);
        }
        public async Task<Task> UpdateParking(int id, Parking parking) // return argument exceptions to tell the controller what to do
        {
            if (id != parking.Id)
            {
                return Task.FromException(new ArgumentException("Id does not match"));
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
                    return Task.FromException(new ArgumentException("Not found"));
                }

                throw;
            }
            return Task.CompletedTask;
        }
        public async Task<Parking> AddParking(Parking parking)
        {

            try
            {
                await _context.Parkings.AddAsync(parking);
                await _context.SaveChangesAsync();

                return parking;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Task> DeleteParking(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);

            if (parking == null)
                return null;

            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();

            return Task.CompletedTask;
        }
        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.Id == id);
        }

    }
}
