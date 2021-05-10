using System;
using System.Collections.Generic;

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            var gui = new GUI();
            var parking = new ParkingActions();
            var leave = new LeaveParkingActions();
            var payment = new PaymentActions();

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
                        if (Occupation.AllParksOccupied()) break;
                        var spacePort = gui.SelectSpacePort();
                        var ship = GUI.GetStarship();
                        if (ship == null) break;
                        parking.Park(ship, spacePort);
                        break;
                    case 1:
                        var port = gui.SelectSpacePort();
                        leave.LeavePark(port);
                        break;
                    case 2:
                        payment.Receipts();
                        break;
                    case 3:
                       gui.AdminPanel();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }
        }
    }
}
