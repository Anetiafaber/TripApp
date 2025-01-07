using Microsoft.EntityFrameworkCore;

namespace Anetia_TripApp.Models
{
    public class TripDbContext : DbContext
    {
        public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {

        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-Many - Destination and Activity
            /*modelBuilder.Entity<Activity>()
                .HasOne(a => a.Destination)
                .WithMany(d => d.Activities)
                .HasForeignKey(a => a.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);*/

            // One-to-Many - Destination and Accommodation
            /*modelBuilder.Entity<Accommodation>()
                .HasOne(a => a.Destination)
                .WithMany(d => d.Accommodations)
                .HasForeignKey(a => a.DestinationId)
                .OnDelete(DeleteBehavior.Cascade);*/

            // One-to-Many - Destination and Trips
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Destination)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-to-Many - Accommodation and Trips
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Accommodation)
                .WithMany(a => a.Trips)
                .HasForeignKey(t => t.AccommodationId)
                .OnDelete(DeleteBehavior.SetNull);

            // Many-to-Many - Trip and Activities
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Activities)
                .WithMany(a => a.Trips);

            modelBuilder.Entity<Destination>().HasData(
                new Destination { DestinationId = 1, Name = "Paris" },
                new Destination { DestinationId = 2, Name = "New York" },
                new Destination { DestinationId = 3, Name = "Tokyo" },
                new Destination { DestinationId = 4, Name = "Dubai" },
                new Destination { DestinationId = 5, Name = "Singapore" }
            );

            modelBuilder.Entity<Activity>().HasData(
                new Activity { ActivityId = 1, Name = "Eiffel Tower Tour"},
                new Activity { ActivityId = 2, Name = "Louvre Museum Visit"},
                new Activity { ActivityId = 3, Name = "Seine River Cruise"},
                new Activity { ActivityId = 4, Name = "Notre-Dame Cathedral Tour"},
                new Activity { ActivityId = 5, Name = "Statue of Liberty Tour"},
                new Activity { ActivityId = 6, Name = "Times Square Visit"},
                new Activity { ActivityId = 7, Name = "Central Park Walk"}
            );

            modelBuilder.Entity<Accommodation>().HasData(
                new Accommodation
                {
                    AccommodationId = 1,
                    Name = "Luxury Hotel Paris"
                },
                new Accommodation
                {
                    AccommodationId = 2,
                    Name = "Paris Central Inn"
                },

                new Accommodation
                {
                    AccommodationId = 3,
                    Name = "Manhattan Suites"
                },
                new Accommodation
                {
                    AccommodationId = 4,
                    Name = "Broadway Grand Hotel"
                },

                new Accommodation
                {
                    AccommodationId = 5,
                    Name = "Shibuya Luxury Hotel"
                },
                new Accommodation
                {
                    AccommodationId = 6,
                    Name = "Tokyo Bay Hotel"
                }
            );

        }
    }
}
