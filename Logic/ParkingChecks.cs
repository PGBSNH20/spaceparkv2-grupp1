using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Models;
using Logic.SpacePark;
using SpaceApi.Models;

namespace Logic
{
    class ParkingChecks
    {
        public async Task<List<Parking>> ParkingLots(string portName) // Get all parking lots
        {
            var parkings = new SpaceParkApi();
            var parkingList = await parkings.GetParkingByPortName(portName);
            List<Parking> list = parkingList.OrderBy(i => i.Id).ToList();
            return list;
        }
        public bool SizeTooBig(Task<List<Parking>> parkings, int index, Starship ship)
        {
            return ship.Length > parkings.Result[index].MaxLength;
        }
    }
}
