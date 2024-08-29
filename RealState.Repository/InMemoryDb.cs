using Microsoft.EntityFrameworkCore;
using RealState.Core.DTOs;
using RealState.Repository.Entity;


namespace RealState.Repository
{
    public class InMemoryDb : DbContext
    {
        public InMemoryDb(DbContextOptions<InMemoryDb> options)
         : base(options) { }

        public DbSet<RoomDTO>  RoomTable{ get; set; }
        public DbSet<ParkingDTO> ParkingTable{ get; set; }
        public DbSet<BuildingDTO> BuildingTable { get; set; }

    }
}
