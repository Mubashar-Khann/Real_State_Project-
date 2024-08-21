

namespace RealState.Repository.Entity
{
    public class Parking
    {
        public int Id { get; set; }
        public string Parking_Name { get; set; }    
        public int Capacity { get; set; } 

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
