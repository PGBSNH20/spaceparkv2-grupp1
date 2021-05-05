using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp;
using Logic.Models;
using Logic.SpacePark;
using SpaceApi.Models;

namespace Logic
{
    public class ParkingActions
    {
        public void Park(Starship ship, SpacePort portName)
        {
            var parkingCheck = new ParkingChecks();
            StandardMessages.LoadingMessage();
            var parkings = parkingCheck.ParkingLots(portName.PortName).Result;
            /*var array = ArrayBuilder.ParkArray(parkings); */// Create string array of all parkings to present to the user in the menu
            Console.Clear();
            var selectedOption = Menu.ShowMenu($"You have selected to park {ship.Name}. Choose parking spot", parkings);

            Finish(parkings, selectedOption, ship); // Add ship to parking in database
        }
        private static void Finish(List<Parking> parkings, int index, Starship ship) // Final check before adding to database
        {
            var spaceApi = new SpaceParkApi();
            var parkingCheck = new ParkingChecks();
            if (parkingCheck.SizeTooBig(parkings, index, ship))
            {
                Console.WriteLine("Too big.");
                Console.ReadKey();
            }
            else
            {
                if (Occupation.ParkIsOccupied(parkings, index))
                {
                    Console.WriteLine("Occupied");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Parking..");
                    var park = parkings.First(p => p.Id == parkings[index].Id);
                    park.Occupied = true;
                    park.ShipName = ship.Name;
                    park.ParkedBy = ship.Driver;
                    var result = spaceApi.Park(park);
                    if (result.IsSuccessful)
                    {
                        Console.WriteLine("Parked");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                        Console.ReadKey();
                    }
                    
                }
            }
        }
    }
}
