using System;
using System.Threading.Tasks;
using Logic;
using Logic.SpacePark;
using Logic.StarWarsApi;
using SpaceApi.Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gui = new GUI();
            var starship = new ShipApi();
            var parking = new ParkingActions();

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
                        // TODO Replace all database calls with API calls in code.
                        var spacePort = gui.SelectSpacePort();
                        var ship = starship.SelectShip();
                        if (ship == null) break;
                        parking.Park(ship, spacePort);



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
