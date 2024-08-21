

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;

namespace RealState.Service
{
    public class BuildingService : IBuildingService
    {
        
        public async Task AddBuildingAsync(BuildingDTO building)
        {
            IBuilding buildingrepository=new BuildingRepository();
           await buildingrepository.AddBuildingAsync(building);

        }

        

        public Task<List<BuildingDTO>> GetAllBuildingAsync()
        {
            IBuilding building = new BuildingRepository();
            return building.GetAllBuildingAsync();
        }

       

        public async Task RemoveBuildingAsync(int id)
        {
            IBuilding repository=new BuildingRepository();
            await repository.RemoveBuildingAsync(id);
        }

       

        public async Task UpdateBuildingAsync(BuildingDTO Update)
        {
            IBuilding building = new BuildingRepository();
            await building.UpdateBuildingAsync(Update);
        }
    }
}
