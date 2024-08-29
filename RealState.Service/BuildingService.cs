

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;

namespace RealState.Service
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingrepository;

        public BuildingService(IBuildingRepository buildingrepository) 
        {
            _buildingrepository = buildingrepository;
        }

        public async Task AddBuildingAsync(BuildingDTO building)
        {           
            await _buildingrepository.AddBuildingAsync(building);
        }

        public Task<List<BuildingDTO>> GetAllBuildingAsync()
        {            
            return _buildingrepository.GetAllBuildingAsync();
        }

        public async Task RemoveBuildingAsync(int id)
        {           
            await _buildingrepository.RemoveBuildingAsync(id);
        }

        public async Task UpdateBuildingAsync(BuildingDTO Update)
        {            
            await _buildingrepository.UpdateBuildingAsync(Update);
        }
    }
}
