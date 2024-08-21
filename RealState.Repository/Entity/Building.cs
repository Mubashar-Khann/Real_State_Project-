

namespace RealState.Repository.Entity
{
    public class Building
    {
        public int Id { get; set; }
        public string Building_Name { get; set; }
        public string Building_Description { get; set; }
        public String Admin_Name { get; set; }
        
        public ICollection<Room> Room { get; set; }

        public ICollection<BuildingSociety> BuildingSocieties { get; set; }

    }
}
