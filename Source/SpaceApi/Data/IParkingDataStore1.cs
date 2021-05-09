using SpaceApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpaceApi.Data
{
    public interface IParkingDataStore1
    {
        Task<Parking> AddParking(Parking parking);
        Task<Task> DeleteParking(int id);
        Task<List<Parking>> GetAllParkings(string portName);
        Task<Parking> GetParkingById(int id);
        Task<Task> UpdateParking(int id, Parking parking);
    }
}