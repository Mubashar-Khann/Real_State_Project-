

using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Repository.Entity;

namespace RealState.Repository
{
    public class RoomRepository : IRoomRepository
    {
        RealStateDbContext Context=new RealStateDbContext();

        private readonly InMemoryDb _inMemoryDb; 
        public RoomRepository(InMemoryDb inMemoryDb)
        {
            _inMemoryDb = inMemoryDb;

        }
        public async Task AddRoomAsync(RoomDTO room)
        {
            var RoomTable = new Room()
            {
                
                Room_Name = room.Room_Name,
                No_Of_Floor = room.No_Of_Floor,
                BuildingId = room.BuildingId
            };
            await Context.Rooms.AddAsync(RoomTable);
            Context.SaveChanges();
            Console.WriteLine(  "Added Record Successfully");
        }

        public async Task<List<RoomDTO>> GetAllRoomAsync()
        {
            var roomList =await Context.Rooms.ToListAsync();
            var Value = Context.Rooms.Select(b => new RoomDTO()
            {
                Id = b.Id,
                Room_Name = b.Room_Name,
                BuildingId = b.BuildingId,
                No_Of_Floor= b.No_Of_Floor,

            }).ToList();
            return Value;
        }

        public async Task RemoveRoomAsync(int id)
        {
            var roomEntity =await  Context.Rooms.FindAsync(id);
            Console.WriteLine(  roomEntity.Id+" "+roomEntity.Room_Name);
            if(roomEntity != null)
            {
                Console.WriteLine(roomEntity.Room_Name + "  " + roomEntity.No_Of_Floor);
                Context.Rooms.Remove(roomEntity);
                await Context.SaveChangesAsync();
                Console.WriteLine("This Object is  Removed");
            }
        }

        public async Task UpdateRoomAsync(RoomDTO Update)
        {
            var updateRoom = await Context.Rooms.FindAsync(Update.Id);

            if(updateRoom != null)
            {
                updateRoom.Room_Name = Update.Room_Name;
                updateRoom.No_Of_Floor = Update.No_Of_Floor;
                updateRoom.BuildingId = Update.BuildingId;
                Context.SaveChanges();
                Console.WriteLine(  "Value Updated");
            }

        }

      
    }
}
