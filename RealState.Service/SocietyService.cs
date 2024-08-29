

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;
using RealState.Repository.Entity;

namespace RealState.Service
{
    public class SocietyService : ISocietyService
    {
        private readonly ISocietyRepository _society;
        public SocietyService(ISocietyRepository society) 
        {
            _society=society;
        }
        public async Task AddSocietyAsync(SocietyDTO Society)
        {
           
          await _society.AddSocietyAsync(Society);
        }

        public async Task<List<SocietyDTO>> GetAllSocietyAsync()
        {
            
            List<SocietyDTO> values=await _society.GetAllSocietyAsync();
            return values;
        }

        public async Task RemoveSocietyAsync(int id)
        {
           
            await _society.RemoveSocietyAsync(id);

        }

        public async Task UpdateSocietyAsync(SocietyDTO Society)
        {
           
            await _society.UpdateSocietyAsync(Society);
        }
    }
}
