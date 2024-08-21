

namespace RealState.Repository.Entity
{
    public class BuildingSociety
    {
        public int BuildingID { get; set; }
        public Building Building { get; set; }
        public int SocietyID { get; set; }
        public Society Society { get; set; } 
    }
}
