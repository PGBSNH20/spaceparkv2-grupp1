using System;
using System.Collections.Generic;
using ConsoleApp;
using Logic.SpacePark;
using RestSharp;
using SpaceApi.Models;

namespace Logic
{
    public class GUI
    {
        public SpacePort SelectSpacePort()
        {
            Console.Clear();
            var spaceApi = new SpaceParkApi();
            var ports = spaceApi.GetAllSpacePorts().Result;
            var arr = ArrayBuilder.PortList(ports);
            var selectedOption = Menu.ShowMenu("Select spaceport", arr);
            return ports[selectedOption];
        }

        public void AdminPanel() // TODO add login credentials
        {
            Console.Clear();
            int selectedOption = Menu.ShowMenu("What would you like to do?", new List<string>
            {
                "Add a new space port",
                "Remove a spaceport",
                "Add parking to spaceport",
                "Remove parking from spaceport",
                "Exit"
            });

            switch (selectedOption)
            {
                case 0:
                    AddSpacePort();
                    break;
                case 1:
                    RemoveSpacePark();
                    break;
                case 2:
                    AddParking();
                    break;
                case 3:
                    RemoveParking();
                    break;
                default:
                    break;
            }
        }
        // Todo move methods under this comment to a better class
        private void AddSpacePort()
        {
            var spaceApi = new SpaceParkApi();
            Console.WriteLine("Enter name of new spaceport");
            string spacePortName = Console.ReadLine();
            SpacePort spacePort = new SpacePort { PortName = spacePortName };
            spaceApi.AddSpacePort(spacePort);
        }
        private void RemoveSpacePark()
        {
            Console.Clear();
            var spaceApi = new SpaceParkApi();
            List<SpacePort> spacePorts = spaceApi.GetAllSpacePorts().Result;
            List<string> nameList = new List<string>();
            foreach (var port in spacePorts)
            {
                nameList.Add(port.PortName);
            }
            //var arr = ArrayBuilder.PortArray(spacePorts);
            int selectedOption = Menu.ShowMenu("Select space port to remove", nameList);
            spaceApi.RemoveSpacePort(spacePorts[selectedOption]);
        }
        private void AddParking()
        {
            Console.Clear();
            var spaceApi = new SpaceParkApi();
            List<SpacePort> spacePorts = spaceApi.GetAllSpacePorts().Result;
            List<string> nameList = new List<string>();
            foreach (var port in spacePorts)
            {
                nameList.Add(port.PortName);
            }
            int selectedOption = Menu.ShowMenu("Choose space port", nameList);
            Console.Clear();
            Console.WriteLine($"Add a new parking to {nameList[selectedOption]}");
            Console.Write("\nEnter parking fee: ");
            int fee = int.Parse(Console.ReadLine());
            Console.Write("\nEnter max ship length:");
            decimal length = decimal.Parse(Console.ReadLine());
            Parking parking = new Parking
            {
                Fee = fee,
                MaxLength = length,
                Occupied = false,
                ParkedBy = null,
                ShipName = null,
                SpacePortId = spacePorts[selectedOption].Id
            };
            spaceApi.AddParking(parking);
        }

        private void RemoveParking()
        {
            Console.Clear();
            var spaceApi = new SpaceParkApi();
            List<SpacePort> spacePorts = spaceApi.GetAllSpacePorts().Result;
            List<string> nameList = new List<string>();
            foreach (var port in spacePorts)
            {
                nameList.Add(port.PortName);
            }
            int selectedOption = Menu.ShowMenu("Choose space port", nameList);
            Console.Clear();
            var parkings = spaceApi.GetParkingByPortName(nameList[selectedOption]).Result;
            nameList.Clear();
            foreach (var park in parkings)
            {
                nameList.Add($"Parking nr.{park.Id} | Fee - {park.Fee} credits | Max length - {park.MaxLength}m | Occupied - {park.Occupied}");
            }
            selectedOption = Menu.ShowMenu($"Choose parking to remove ", nameList);
            spaceApi.RemoveParking(parkings[selectedOption]);
        }
        public static SpaceApi.Models.Starship GetStarship()
        {
            var personName = StandardMessages.NameReader();
            var api = new SpaceParkApi();
            var ships = api.GetPersonsStarshipsAvailableForParking(personName).Result;
            if (ships!=null)
            {
                if (ships.Count != 0)
                {
                    Console.Clear();
                    var selectedOption = Menu.ShowMenu($"Welcome {personName}. What ship will you be parking today?\n", ArrayBuilder.ShipList(ships));
                    var selectedShip = ships[selectedOption];
                    selectedShip.Driver = personName; // Assign the name to the driver property of the selected ship.
                    return selectedShip;
                }
                StandardMessages.NoShipsAvailableMessage(); // If the user does not have any ships or all available ships for the user is already parked
                return null;
            }
            StandardMessages.NotAllowedMessage(); // If the user does not exist in the API
            return null;

        }


    }
}


