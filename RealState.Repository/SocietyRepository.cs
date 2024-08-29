using RealState.Core.DTOs;
using RealState.Core.Repository;
using Microsoft.EntityFrameworkCore;
using RealState.Repository.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Data.SqlClient;


namespace RealState.Repository
{
    public class SocietyRepository : ISocietyRepository
    {
       public string connectionString = "Data Source=MUBASHAR_KHAN; Initial Catalog=realstate; Trusted_Connection=True;TrustServerCertificate=True;";

        RealStateDbContext context = new RealStateDbContext();

        private readonly InMemoryDb _inMemoryDb;
        
        public SocietyRepository(InMemoryDb db)
        {
            _inMemoryDb = db;
        }

        public async Task AddSocietyAsync(SocietyDTO Society)
        {
            var context = new RealStateDbContext();
            var entity = new Entity.Society()
            {
                Society_Name = Society.Society_Name,
                Society_Description = Society.Society_Description,
                Society_Location = Society.Society_Location,
            };
            await context.Societies.AddAsync(entity);
            context.SaveChanges();
            Console.WriteLine( "Values Inserted");
        }

        public async Task<List<SocietyDTO>> GetAllSocietyAsync()  // Stored Procedure of GetAllSocieties

        {
            var storeProcedure = "GetSocieties";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(storeProcedure,sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader=sqlCommand.ExecuteReader();
            List<SocietyDTO> list = new List<SocietyDTO>();
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    var society = new SocietyDTO()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Society_Name = reader.GetString(reader.GetOrdinal("Society_Name")),
                        Society_Description = reader.GetString(reader.GetOrdinal("Society_Description")),
                        Society_Location = reader.GetString(reader.GetOrdinal("Society_Location"))
                    };
                    list.Add(society);
                }
            }
            return list;
        }
        public  async Task RemoveSocietyAsync(int id)
        {
            var context = new RealStateDbContext();
            //Console.WriteLine("Values of id is " + id);
            var  removeSocietyObject= await context.Societies.FindAsync(id);
            Console.WriteLine(  removeSocietyObject.Id+"  "+removeSocietyObject.Society_Location+"  "+removeSocietyObject.Society_Name);
            
             if (removeSocietyObject!= null)
              {
                //await context.Societies.Remove(remove);
                  context.Societies.Remove(removeSocietyObject);
                  await context.SaveChangesAsync();
                  Console.WriteLine(  "Value Deleted");
              }
            
        }
        public async Task UpdateSocietyAsync(SocietyDTO Society)
        {
            var entity =  context.Societies.FirstOrDefault(b=>b.Id == Society.Id);
            if (entity != null)
            {
                entity.Society_Name = Society.Society_Name;
                entity.Society_Description = Society.Society_Description;
                entity.Society_Location=Society.Society_Location;
                await context.SaveChangesAsync();
                Console.WriteLine(  "Updated Successfully");
            
            }
            

        }

       
    }
}
