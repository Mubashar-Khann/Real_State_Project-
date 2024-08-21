

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;

namespace RealState.Service
{
    public class ParkingService : IParkingService
    {
        public async Task AddParkingAsync(ParkingDTO dto)
        {
            IParking parking = new ParkingRepository();
            await parking.AddParkingAsync(dto);
        }

        public async Task<List<ParkingDTO>> GetAllParkingAsync()
        {
            IParking parking = new ParkingRepository();
            return await parking.GetAllParkingAsync();
        }

        public async Task RemoveParkingAsync(int id)
        {
            IParking parking = new ParkingRepository();
            await parking.RemoveParkingAsync(id);
        }

        public async Task UpdateParkingAsync(ParkingDTO dto)
        {
            IParking parking = new ParkingRepository();
            await parking.UpdateParkingAsync(dto);
        }
    }
}
