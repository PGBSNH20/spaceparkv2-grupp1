using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceApi.Models
{
    public class SpacePark
    {
        public List<SpacePort> SpaceParks { get; set; }
    }
    public class SpacePort
    {
        public string PortName { get; set; }
        public List<Parking> Parkings { get; set; }
    }
}
