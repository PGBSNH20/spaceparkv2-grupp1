using System;
using System.Collections.Generic;
using Logic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var gui = new GUI();
            var parking = new ParkingActions();

            var running = true;
            while (running)
            {
                StandardMessages.StartMessage();
                var selectedOption = Menu.ShowMenu("SpacePark Menu", new List<string>
                {
                    "Park Ship",
                    "Leave SpacePark",
                    "Show Receipts",
                    "Admin Page",
                    "Exit Menu"
                });
                switch (selectedOption)
                {
                    case 0:
                        var spacePort = gui.SelectSpacePort();
                        var ship = GUI.GetStarship();
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
                       // gui.AdminPanel();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }
    }
}
