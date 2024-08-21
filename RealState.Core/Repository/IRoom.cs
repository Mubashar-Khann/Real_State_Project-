using RealState.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Repository
{
    public interface IRoom
    {
        Task AddRoomAsync(RoomDTO room);
        Task RemoveRoomAsync(int id);
        Task UpdateRoomAsync(RoomDTO update);
        Task<List<RoomDTO>> GetAllRoomAsync();
    }
}
