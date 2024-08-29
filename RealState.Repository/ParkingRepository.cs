

using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Repository.Entity;

namespace RealState.Repository
{
    public class ParkingRepository : IParkingRepository
    {
        RealStateDbContext context= new RealStateDbContext();
        private readonly InMemoryDb _inMemoryDb2;

        public ParkingRepository(InMemoryDb inMemoryDb2)
        {
            _inMemoryDb2 = inMemoryDb2; 
        }

        public async Task AddParkingAsync(ParkingDTO dto)
        {
            var pkingobj = new Parking()
            {
                Parking_Name=dto.Parking_Name,
                Capacity=dto.Capacity,
                RoomId=dto.RoomId,
            };            
            await context.Parkings.AddAsync(pkingobj);  
            context.SaveChanges();
            Console.WriteLine("Record Added");
            //return context.Parkings.ToList();
        }

        public async Task<List<ParkingDTO>> GetAllParkingAsync()
        {
            var  GetAll = await context.Parkings.ToListAsync();
             var GetAll2 = context.Parkings.Select( b=> new ParkingDTO()
             {
                 Id=b.Id,
                 Parking_Name=b.Parking_Name,
                 Capacity=b.Capacity,
                 RoomId=b.RoomId,
             }).ToList();
             return GetAll2;
        }

        public async Task RemoveParkingAsync(int id)
        {
            var FindingObj=await context.Parkings.FirstOrDefaultAsync(b => b.Id==id);
            Console.WriteLine(FindingObj.Parking_Name + "  " + FindingObj.Capacity);
            if (FindingObj != null) 
            {
                context.Parkings.Remove(FindingObj);    
                context.SaveChanges();
                Console.WriteLine("Values Deleted");
            }
        }

        public async Task UpdateParkingAsync(ParkingDTO dto)
        {
            var updateObj = await context.Parkings.FindAsync(dto.Id);

            if (updateObj != null)
            {
                updateObj.Parking_Name = dto.Parking_Name;
                updateObj.Capacity = dto.Capacity;
                updateObj.RoomId= dto.RoomId;
                context.SaveChanges();
                Console.WriteLine(  "Value Updated");
            }
               
        }

        public async Task AddPArkingAsync(ParkingDTO Parking)
        {
            
        }

    }
}
