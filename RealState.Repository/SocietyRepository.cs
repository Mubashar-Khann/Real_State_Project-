using RealState.Core.DTOs;
using RealState.Core.Repository;
using Microsoft.EntityFrameworkCore;
using RealState.Repository.Entity;
using System.Linq;


namespace RealState.Repository
{
    public class SocietyRepository : ISociety
    {
        RealStateDbContext context = new RealStateDbContext();

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

        public async Task<List<SocietyDTO>> GetAllSocietyAsync()
        {
            List<Society> values = await context.Societies.ToListAsync();
            var societyDTOs = context.Societies.Select(s => new SocietyDTO
            {
                Id = s.Id,
                Society_Name = s.Society_Name,
                Society_Description= s.Society_Description,
                Society_Location= s.Society_Location,
            }).ToList();
            return societyDTOs;
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
