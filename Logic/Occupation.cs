using System.Collections.Generic;
using System.Linq;
using Logic.SpacePark;
using SpaceApi.Models;

namespace Logic
{
    public class Occupation
    {
        public static bool AllParksOccupied() // Check if all parkings are occupied
        {
            var api = new SpaceParkApi();
            StandardMessages.LoadingMessage();
            var parkings = api.GetAllParkings();

            if (!parkings.Result.All(i => i.Occupied)) return false;
            StandardMessages.FullParkMessage();
            return true;
        }
        public static bool ParkIsOccupied(List<Parking> parkings, int index) // Check if specific park is occupied
        {
            var api = new SpaceParkApi();
            var parkingsList = api.GetAllParkings();
            var park = parkingsList.Result.First(p => p.Id == parkings[index].Id);
            return park.Occupied;
        }
    }
}
