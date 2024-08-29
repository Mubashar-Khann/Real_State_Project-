

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;

namespace RealState.Service
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository _parking;
        public ParkingService(IParkingRepository parking) 
        {
            _parking = parking;
        }
        public async Task AddParkingAsync(ParkingDTO dto)
        {
            
            await _parking.AddParkingAsync(dto);
        }

        public async Task<List<ParkingDTO>> GetAllParkingAsync()
        {
            
            return await _parking.GetAllParkingAsync();
        }

        public async Task RemoveParkingAsync(int id)
        {
            ;
            await _parking.RemoveParkingAsync(id);
        }

        public async Task UpdateParkingAsync(ParkingDTO dto)
        {

            await _parking.UpdateParkingAsync(dto);
        }
    }
}
