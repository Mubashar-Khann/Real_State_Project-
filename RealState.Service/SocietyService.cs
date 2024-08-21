

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;
using RealState.Repository.Entity;

namespace RealState.Service
{
    public class SocietyService : ISocietyService
    {
        

        public async Task AddSocietyAsync(SocietyDTO Society)
        {
            ISociety societyRepository = new SocietyRepository();
          await  societyRepository.AddSocietyAsync(Society);
        }

        public async Task<List<SocietyDTO>> GetAllSocietyAsync()
        {
            ISociety ss=new SocietyRepository();
            List<SocietyDTO> values=await ss.GetAllSocietyAsync();
            return values;
        }

        public async Task RemoveSocietyAsync(int id)
        {
            ISociety societyRepository = new SocietyRepository();
            await societyRepository.RemoveSocietyAsync(id);

        }

        public async Task UpdateSocietyAsync(SocietyDTO Society)
        {
            ISociety societyService = new SocietyRepository();
            await  societyService.UpdateSocietyAsync(Society);
        }
    }
}
