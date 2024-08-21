

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RealState.Service
{
    public class RoomService : IRoomService
    {
        public async Task AddRoomAsync(RoomDTO room)
        {
            IRoom RoomObject = new RoomRepository();
            await RoomObject.AddRoomAsync(room);
        }

        public async Task<List<RoomDTO>> GetAllRoomAsync()
        {
          IRoom room = new RoomRepository();
            return  await room.GetAllRoomAsync();
        }

        public async Task RemoveRoomAsync(int id)
        {
            IRoom room=new RoomRepository();
           await room.RemoveRoomAsync(id);
        }

        public async Task UpdateRoomAsync(RoomDTO update)
        {
            IRoom room = new RoomRepository();
            await room.UpdateRoomAsync(update);
        }
    }
}
