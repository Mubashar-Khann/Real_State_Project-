
using RealState.Core.DTOs;
using System.Threading.Tasks;

namespace RealState.Core.Repository
{
    public interface IParking
    {
        Task AddParkingAsync(ParkingDTO dto);
        Task RemoveParkingAsync(int id);
        Task UpdateParkingAsync(ParkingDTO dto);
        Task<List<ParkingDTO>> GetAllParkingAsync();
    }
}
