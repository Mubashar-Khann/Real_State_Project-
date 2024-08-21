

namespace RealState.Repository.Entity
{
    public class Society
    {
        public int Id { get; set; }
        public string Society_Name { get; set; }
        public string Society_Description { get; set; }
        public string Society_Location { get; set; }

        public ICollection<BuildingSociety> BuildingSocieties { get; set; }    
    }
}
