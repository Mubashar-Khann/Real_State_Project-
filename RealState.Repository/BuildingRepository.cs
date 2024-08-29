

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Repository.Entity;
using System.Data;

namespace RealState.Repository
{
    public class BuildingRepository : IBuildingRepository
    {

        public string connectionString = "Data Source=MUBASHAR_KHAN; Initial Catalog=realstate; Trusted_Connection=True;TrustServerCertificate=True;";


        private readonly RealStateDbContext _context=new RealStateDbContext();
        private readonly InMemoryDb _inMemoryDb;
       public BuildingRepository(InMemoryDb db)
        {
            _inMemoryDb = db;
        }
       

        public async Task AddBuildingAsync(BuildingDTO building)
        {
            var obj = new Building()
            {
                Building_Name = building.Building_Name,
                Building_Description = building.Building_Description,
                Admin_Name = building.Admin_Name,
            };
            await _context.Buildings.AddAsync(obj);
            _context.SaveChanges();
            Console.WriteLine("Record Added");

            Console.WriteLine(  "Values Inserted Succesfully");
        }

        public async Task<List<BuildingDTO>> GetAllBuildingAsync()
        {
            var storeProcedure = "GetBuildings";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(storeProcedure, sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            var list = new List<BuildingDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var society = new BuildingDTO()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Building_Name = reader.GetString(reader.GetOrdinal("Building_Name")),
                        Building_Description = reader.GetString(reader.GetOrdinal("Building_Description")),
                        Admin_Name = reader.GetString(reader.GetOrdinal("Admin_Name"))
                    };
                    list.Add(society);


                   
                }
            }
            return list;
        }

        public async Task RemoveBuildingAsync(int id)
        {
            var removeBuildingObject = _context.Buildings.Find(id);
            if (removeBuildingObject != null)
            {
                Console.WriteLine(removeBuildingObject.Building_Name + "  " + removeBuildingObject.Admin_Name);
                _context.Buildings.Remove(removeBuildingObject);
                _context.SaveChanges();
                Console.WriteLine("This object is Deleted");
            }
        }

        public async Task UpdateBuildingAsync(BuildingDTO update)
        {
            var buildingUpdate = _context.Buildings.Find(update.Id);

            if (buildingUpdate != null)
            {
                buildingUpdate.Building_Name = update.Building_Name;
                buildingUpdate.Building_Description = update.Building_Description;
                buildingUpdate.Admin_Name = update.Admin_Name;
                _context.SaveChanges();
                Console.WriteLine("Update Successfully");
            }
          
            
        }
    }

}



