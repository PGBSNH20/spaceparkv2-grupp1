using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApp;
using Logic.SpacePark;
using SpaceApi.Models;

namespace Logic
{
    class Occupation
    {
        private readonly SpaceParkApi _api;
        public Occupation(SpaceParkApi api)
        {
            _api = api;
        }
        //public static bool AllParksOccupied() // Check if all parkings are occupied
        //{
        //    StandardMessages.LoadingMessage();
        //    List<Task<Parking>> parkings = _api.GetParking();

        //    if (!context.Parkings.All(i => i.Occupied)) return false;
        //    StandardMessages.FullParkMessage();
        //    return true;
        //}
        //public static bool ParkIsOccupied(Task<List<Parking>> parkings, int index) // Check if specific park is occupied
        //{
            
        //    var park = context.Parkings.First(p => p.Id == parkings.Result[index].Id);
        //    return park.Occupied;
        //}
    }
}
