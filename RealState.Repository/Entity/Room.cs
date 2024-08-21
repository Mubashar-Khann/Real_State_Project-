

namespace RealState.Repository.Entity
{
    public class Room
    {
       public  int Id { get; set; }    
       public  String Room_Name { get; set; }   
       public  String No_Of_Floor { get; set; }

        public int BuildingId { get; set; }
        public Building Building { get; set; } 

       
        public Parking Parking { get; set; }
    }
}
