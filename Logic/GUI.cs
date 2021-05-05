using System;
using ConsoleApp;
using Logic.SpacePark;
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
    }
}
