using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Logic.SpacePark;
using RestSharp;
using SpaceApi.Models;

namespace SpaceApiTests
{
    class SpaceParkApiStub : ISpaceParkApi
    {
        public async Task<List<Parking>> GetAllParkings() // Return 4 parkings
        {
            List<Parking> parkings = new List<Parking>();

            parkings.Add(new Parking { Fee = 100, Id = 1, MaxLength = 200, Occupied = false, SpacePortId = 1, ShipName = null, ParkedBy = null });
            parkings.Add(new Parking { Fee = 100, Id = 1, MaxLength = 200, Occupied = false, SpacePortId = 1, ShipName = null, ParkedBy = null });
            parkings.Add(new Parking { Fee = 100, Id = 1, MaxLength = 200, Occupied = false, SpacePortId = 1, ShipName = null, ParkedBy = null });
            parkings.Add(new Parking { Fee = 100, Id = 1, MaxLength = 200, Occupied = false, SpacePortId = 1, ShipName = null, ParkedBy = null });

            return parkings;
        }

        public async Task<List<SpacePort>> GetAllSpacePorts()
        {
            var parkings = GetAllParkings();
            List<SpacePort> spacepots = new List<SpacePort>();

            spacepots.Add(new SpacePort { Id = 1, Parkings = parkings.Result, PortName = "Port1" });
            spacepots.Add(new SpacePort { Id = 1, Parkings = parkings.Result, PortName = "Port2" });
            spacepots.Add(new SpacePort { Id = 1, Parkings = parkings.Result, PortName = "Port3" });

            return spacepots;

        }

        public IRestResponse Park(Parking parking)
        {
            if (parking != null)
            {
                return new RestResponse
                {
                    ResponseStatus = ResponseStatus.Completed
                };
            }

            return new RestResponse
            {
                ResponseStatus = ResponseStatus.Error
            };
        }

        public IRestResponse RemoveParking(Parking parking)
        {
            if (parking != null)
            {
                return new RestResponse
                {
                    ResponseStatus = ResponseStatus.Completed
                };
            }

            return new RestResponse
            {
                ResponseStatus = ResponseStatus.Error
            };
        }

        public IRestResponse AddParking(Parking parking)
        {
            if (parking != null)
            {
                return new RestResponse
                {
                    ResponseStatus = ResponseStatus.Completed
                };
            }

            return new RestResponse
            {
                ResponseStatus = ResponseStatus.Error
            };
        }

        public IRestResponse RemoveSpacePort(SpacePort spacePort)
        {
            if (spacePort != null)
            {
                return new RestResponse
                {
                    ResponseStatus = ResponseStatus.Completed
                };
            }

            return new RestResponse
            {
                ResponseStatus = ResponseStatus.Error
            };
        }

        public IRestResponse AddSpacePort(SpacePort spacePort)
        {
            if (spacePort != null)
            {
                return new RestResponse
                {
                    ResponseStatus = ResponseStatus.Completed
                };
            }

            return new RestResponse
            {
                ResponseStatus = ResponseStatus.Error
            };
        }
    }
}
