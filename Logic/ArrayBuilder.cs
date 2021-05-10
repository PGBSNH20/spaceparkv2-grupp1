using System.Collections.Generic;
using System.Threading.Tasks;
using SpaceApi.Models;

namespace Logic
{
    public class ArrayBuilder
    {
        public static List<string> ParkArray(List<Parking> parkings)
        {
            var tempList = new List<string>();
            for (int i = 0; i < parkings.Count; i++)
            {
                tempList.Add(
                    $"Parking Spot {parkings[i].Id}. Max ship length: {parkings[i].MaxLength}m. Fee: {parkings[i].Fee} credits. Occupied? {parkings[i].Occupied}");
            }
            return tempList;
        }
        public static List<string> ShipList(List<Starship> ship)
        {
            var shipsPrint = new List<string>();
            for (int i = 0; i < ship.Count; i++)
            {
                shipsPrint.Add($"{ship[i].Name} ({ship[i].Length}m)");
            }
            return shipsPrint;
        }

        public static List<string> PortList(List<SpacePort> ports)
        {
            var portList = new List<string>();
            for (int i = 0; i < ports.Count; i++)
            {
                portList.Add($"{ports[i].PortName}");
            }
           
            return portList;
        }
        public static List<string> OnLeaveArray(Task<List<Parking>> parkings)
        {
            var tempList = new List<string>();
            for (int i = 0; i < parkings.Result.Count; i++)
            {
                tempList.Add(parkings.Result[i].Occupied == false
                    ? $"Parking Spot {parkings.Result[i].Id}."
                    : $"Parking Spot {parkings.Result[i].Id}. Occupied by {parkings.Result[i].ShipName}");
            }
            return tempList;
        }
    }
}

