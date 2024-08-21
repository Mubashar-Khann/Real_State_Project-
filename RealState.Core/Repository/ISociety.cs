using RealState.Core.DTOs;


namespace RealState.Core.Repository
{
    public  interface ISociety
    {
        Task AddSocietyAsync(SocietyDTO Society);
        Task RemoveSocietyAsync(int id);
        Task UpdateSocietyAsync(SocietyDTO Society);
        Task<List<SocietyDTO>> GetAllSocietyAsync();
    }
}
