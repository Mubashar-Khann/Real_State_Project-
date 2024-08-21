

using RealState.Core.DTOs;

namespace RealState.Core.Service
{
    public interface ISocietyService
    {
        Task AddSocietyAsync(SocietyDTO Society);
        Task RemoveSocietyAsync(int id);
        Task UpdateSocietyAsync(SocietyDTO Society);
        Task<List<SocietyDTO>> GetAllSocietyAsync();
    }
}
