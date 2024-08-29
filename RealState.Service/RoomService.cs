

using RealState.Core.DTOs;
using RealState.Core.Repository;
using RealState.Core.Service;
using RealState.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RealState.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _room;
        public RoomService(IRoomRepository room) 
        {
            _room = room;
        }
        public async Task AddRoomAsync(RoomDTO room)
        {
            await _room.AddRoomAsync(room);
        }

        public async Task<List<RoomDTO>> GetAllRoomAsync()
        {
        
            return await _room.GetAllRoomAsync();
        }

        public async Task RemoveRoomAsync(int id)
        {
            
           await _room.RemoveRoomAsync(id);
        }

        public async Task UpdateRoomAsync(RoomDTO update)
        {
           
            await _room.UpdateRoomAsync(update);
        }
    }
}
