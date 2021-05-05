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
            //var arr = ArrayBuilder.PortArray(ports);
            var selectedOption = Menu.ShowMenu("Select spaceport", ports);

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
            var spaceApi = new SpaceParkApi();
            List<SpacePort> spacePorts = spaceApi.GetAllSpacePorts().Result;
            List<string> nameList = new List<string>();
            foreach(var port in spacePorts)
            {
                nameList.Add(port.PortName);
            }
            //var arr = ArrayBuilder.PortArray(spacePorts);
            int selectedOption = Menu.ShowMenu("Select space port to remove", nameList);
            spaceApi.RemoveSpacePort(spacePorts[selectedOption]);
        }
    }
}
