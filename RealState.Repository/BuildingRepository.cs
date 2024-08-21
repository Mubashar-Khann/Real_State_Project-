

using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Repository.Entity;

namespace RealState.Repository
{
    public class BuildingRepository : IBuilding
    {
        RealStateDbContext context = new RealStateDbContext();
        public async Task AddBuildingAsync(BuildingDTO building)
        {
            
            var buildingEntity = new Building()
            {
                Building_Name = building.Building_Name,
                Building_Description = building.Building_Description,
                Admin_Name = building.Admin_Name,
            };
            context.Buildings.Add(buildingEntity);
            context.SaveChanges();
            Console.WriteLine(  "Values Inserted Succesfully");
        }

        public async Task<List<BuildingDTO>> GetAllBuildingAsync()
        {
            var BuildingData=await context.Buildings.ToListAsync();

            var BuildingDto = context.Buildings.Select(b => new BuildingDTO()
            {
                Id = b.Id,
                Building_Name = b.Building_Name,
                Building_Description = b.Building_Description,
                Admin_Name = b.Admin_Name,
            }).ToList();
            return BuildingDto;

        }

        public async Task RemoveBuildingAsync(int id)
        {
            var removeBuildingObject = context.Buildings.Find(id);
            if (removeBuildingObject != null)
            {
                Console.WriteLine(removeBuildingObject.Building_Name + "  " + removeBuildingObject.Admin_Name);
                context.Buildings.Remove(removeBuildingObject);
                context.SaveChanges();
                Console.WriteLine("This object is Deleted");
            }
        }

        public async Task UpdateBuildingAsync(BuildingDTO update)
        {
            var buildingUpdate = context.Buildings.Find(update.Id);

            if (buildingUpdate != null)
            {
                buildingUpdate.Building_Name = update.Building_Name;
                buildingUpdate.Building_Description = update.Building_Description;
                buildingUpdate.Admin_Name = update.Admin_Name;
                context.SaveChanges();
                Console.WriteLine("Update Successfully");
            }
          
            
        }
    }

    }

