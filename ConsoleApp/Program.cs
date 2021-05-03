using System;
using System.Threading.Tasks;
using Logic.SpacePark;
using SpaceApi.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var running = true;
            while (running)
            {
                StandardMessages.StartMessage();
                var selectedOption = Menu.ShowMenu("SpacePark Menu", new[]
                {
                    "Park Ship",
                    "Leave SpacePark",
                    "Show Receipts",
                    "Exit Menu"
                });
                switch (selectedOption)
                {
                    case 0:
                        var park = SpaceParkApi.GetAllParkings(); // FOr testing
                        Console.WriteLine(park.Result); // TODO Replace all database calls with API calls in code.

                        //if (Occupation.AllParksOccupied()) break;
                        //var ship = starship.SelectShip();
                        //if (ship == null) break;
                        ////parking.Park(ship);
                        break;
                    case 1:
                        //leave.LeavePark();
                        break;
                    case 2:
                        //payment.Receipts();
                        break;
                    case 3:
                        running = false;
                        break;
                }
            }
        }
    }
}
