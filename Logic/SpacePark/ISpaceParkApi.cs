using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using SpaceApi.Models;

namespace Logic.SpacePark
{
    public interface ISpaceParkApi
    {
        Task<List<Parking>> GetAllParkings();
        Task<List<SpacePort>> GetAllSpacePorts();
        IRestResponse Park(Parking parking);
        IRestResponse RemoveParking(Parking parking);
        IRestResponse AddParking(Parking parking);
        IRestResponse RemoveSpacePort(SpacePort spacePort);
        IRestResponse AddSpacePort(SpacePort spacePort);
    }
}
