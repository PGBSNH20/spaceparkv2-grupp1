﻿using System;
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
                       Task<Parking> park = SpaceParkApi.GetParking(1);
                       var s = park.Result;

                        //if (Occupation.AllParksOccupied()) break;
                        ////var ship = starship.SelectShip();
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