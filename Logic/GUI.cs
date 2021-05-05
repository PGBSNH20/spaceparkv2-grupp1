using System;
using ConsoleApp;
using Logic.SpacePark;
using RestSharp;
using SpaceApi.Models;

namespace Logic
{
    public class GUI
    {
        public string SelectSpacePort()
        {
            Console.Clear();
            var spaceApi = new SpaceParkApi();
            var ports = spaceApi.GetAllSpacePorts();
            var arr = ArrayBuilder.PortArray(ports);
            var selectedOption = Menu.ShowMenu("Select spaceport", arr);

            return arr[selectedOption];
        }

        public void AdminPanel() // TODO add login credentials
        {
            Console.Clear();
            int selectedOption = Menu.ShowMenu("What would you like to do?", new string[]
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

                default:
                    break;
            }
        }
    }
}
