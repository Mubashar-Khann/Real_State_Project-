

using RealState.Core.DTOs;

namespace RealState.Core.Service
{
    public interface IBuildingService
    {
        Task AddBuildingAsync(BuildingDTO building);
        Task RemoveBuildingAsync(int id);
        Task UpdateBuildingAsync(BuildingDTO update);
        Task<List<BuildingDTO>> GetAllBuildingAsync();
    }
}
