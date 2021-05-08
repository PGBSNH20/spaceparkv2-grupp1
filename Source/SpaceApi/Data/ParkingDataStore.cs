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
                return await _context.SpacePorts.Where(p => p.PortName == portName).Include(i => i.Parkings)
                        .SelectMany(t => t.Parkings).ToListAsync();
            }
            return await _context.Parkings.ToListAsync();
        }
        public async Task<Parking> GetParkingById(int id)
        {
            var parking = await _context.Parkings.FindAsync(id);

            if (parking == null)
            {
                return null;
            }
            return parking;
        }
    }

    public interface IParkingDataStore
    {
        Task<List<Parking>> GetAllParkings(string portName);
        Task<Parking> GetParkingById(int id);
    }
}
