using SpaceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceApi.Data
{
    public interface ISpacePortDataStore
    {
        Task<List<SpacePort>> GetAllSpacePorts();
        Task<SpacePort> GetSpacePortById(int id);
        Task<Task> UpdateSpacePort(int id, SpacePort spacePort);
        Task<SpacePort> AddSpacePort(SpacePort spacePort);
        Task<Task> DeleteSpacePort(int id);

    }
}