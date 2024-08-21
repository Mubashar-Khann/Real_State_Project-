

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RealState.Repository.Entity;

namespace RealState.Repository
{
    public class RealStateDbContext :DbContext
    {
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Society> Societies { get; set; }

        public virtual DbSet<BuildingSociety> BuildingSocieties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=mubashar_khan;database=realstate;trusted_connection = true;trustservercertificate=true");

           // optionsbuilder.usesqlserver("server=mubashar_khan;database=realstate;trusted_connection = true;trustservercertificate=true");
        
        }
       



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One To Many Relation Buildig has Many Room and Multiple rooms have One Building

            modelBuilder.Entity<Building>()     
                        .HasMany(r => r.Room)
                        .WithOne(r => r.Building)
                        .HasForeignKey(r =>r.BuildingId)
                        .OnDelete(DeleteBehavior.Cascade);

            //One To One Relation Between Room and Parking
            modelBuilder.Entity<Room>()          
                        .HasOne<Parking>(r => r.Parking)
                        .WithOne(r => r.Room)
                        .HasForeignKey<Parking>(r => r.RoomId)
                        .OnDelete(DeleteBehavior.Cascade);

            //Declare  The Foreign Keys used in 3rd Table 
            modelBuilder.Entity<BuildingSociety>().HasKey(t => new { t.SocietyID, t.BuildingID });

            modelBuilder.Entity<BuildingSociety>()          // Attach the BuildingId  in 3rd Table
                        .HasOne<Building>(r => r.Building)
                        .WithMany(r => r.BuildingSocieties)
                        .HasForeignKey(r => r.BuildingID)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BuildingSociety>()        // Attach The SocietyId To the 3rd Table
                        .HasOne<Society>(r => r.Society)
                        .WithMany(r => r.BuildingSocieties)
                        .HasForeignKey(r => r.SocietyID)
                         .OnDelete(DeleteBehavior.Cascade); ;

        }


    }
}
