

using RealState.Core.DTOs;

namespace RealState.Core.Service
{
    public interface IRoomService
    {
        Task AddRoomAsync(RoomDTO room);
        Task RemoveRoomAsync(int id);
        Task UpdateRoomAsync(RoomDTO update);
        Task<List<RoomDTO>> GetAllRoomAsync();
    }
}
