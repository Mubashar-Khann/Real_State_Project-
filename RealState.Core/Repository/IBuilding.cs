

using RealState.Core.DTOs;

namespace RealState.Core.Repository
{
    public interface IBuilding
    {
        Task AddBuildingAsync(BuildingDTO building);
        Task RemoveBuildingAsync(int id);
        Task UpdateBuildingAsync(BuildingDTO update);
        Task<List<BuildingDTO>> GetAllBuildingAsync();
    }
}
