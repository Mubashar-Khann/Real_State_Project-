

using RealState.Core.DTOs;

namespace RealState.Core.Service
{
    public interface IParkingService
    {
        Task AddParkingAsync(ParkingDTO dto);
        Task RemoveParkingAsync(int id);
        Task UpdateParkingAsync(ParkingDTO dto);
        Task<List<ParkingDTO>> GetAllParkingAsync();
    }
}
