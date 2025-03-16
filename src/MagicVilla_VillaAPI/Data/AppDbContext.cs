using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>()
                .Property(v => v.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Villa>()
                .Property(v => v.LastUpdatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<VillaNumber>()
                .Property(v => v.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<VillaNumber>()
                .Property(v => v.LastUpdatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Occupancy = 5,
                    Amenity = "Pool, Wi-Fi",
                    Sqft = 550,
                    Rate = 200,
                    ImageUrl = "https://villascroatia.com/villas/modern-luxury-villa-with-pool-in-medulin",
                },
               new Villa()
               {
                   Id = 2,
                   Name = "Beachside Villa",
                   Details = "Enjoy the ocean breeze in this cozy villa by the beach, perfect for family vacations.",
                   Occupancy = 4,
                   Amenity = "Beach Access, BBQ Area, Wi-Fi",
                   Sqft = 450,
                   Rate = 250,
                   ImageUrl = "https://unsplash.com/photos/villa-beachside"
               },
                new Villa()
                {
                    Id = 3,
                    Name = "Mountain Retreat",
                    Details = "Surrounded by nature, this villa offers stunning mountain views and tranquility.",
                    Occupancy = 6,
                    Amenity = "Fireplace, Hiking Trails, Wi-Fi",
                    Sqft = 700,
                    Rate = 300,
                    ImageUrl = "https://pixabay.com/photos/mountain-villa-retreat"
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Urban Luxe",
                    Details = "Located in the heart of the city, this modern villa features sleek interiors and convenience.",
                    Occupancy = 3,
                    Amenity = "City View, Smart Home Features",
                    Sqft = 350,
                    Rate = 400,
                    ImageUrl = "https://luxuryurbanvilla.com"
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Tropical Paradise",
                    Details = "Surrounded by lush greenery and exotic plants, this villa is a tropical dream come true.",
                    Occupancy = 5,
                    Amenity = "Private Pool, Outdoor Shower, Wi-Fi",
                    Sqft = 600,
                    Rate = 350,
                    ImageUrl = "https://tropicalvillas.com/paradise"
                },
                new Villa()
                {
                    Id = 6,
                    Name = "Countryside Charm",
                    Details = "A rustic villa nestled in the countryside, perfect for a peaceful escape.",
                    Occupancy = 4,
                    Amenity = "Garden, Fireplace, Wi-Fi",
                    Sqft = 500,
                    Rate = 180,
                    ImageUrl = "https://pixabay.com/photos/countryside-villa"
                },
                new Villa()
                {
                    Id = 7,
                    Name = "Lakeside Haven",
                    Details = "Relax by the water in this beautiful lakeside villa, ideal for a romantic getaway.",
                    Occupancy = 2,
                    Amenity = "Lake View, Private Dock, Wi-Fi",
                    Sqft = 400,
                    Rate = 275,
                    ImageUrl = "https://lakesidevillas.com/haven"
                },
                new Villa()
                {
                    Id = 8,
                    Name = "Luxury Penthouse",
                    Details = "Experience ultimate luxury in this spacious penthouse with panoramic city views.",
                    Occupancy = 4,
                    Amenity = "Infinity Pool, Private Elevator, Wi-Fi",
                    Sqft = 800,
                    Rate = 500,
                    ImageUrl = "https://unsplash.com/photos/luxury-penthouse"
                },
                new Villa()
                {
                    Id = 9,
                    Name = "Cozy Cottage",
                    Details = "A charming and quaint cottage surrounded by picturesque gardens.",
                    Occupancy = 3,
                    Amenity = "Garden, Patio, Wi-Fi",
                    Sqft = 300,
                    Rate = 150,
                    ImageUrl = "https://pixabay.com/photos/cozy-cottage"
                },
                new Villa()
                {
                    Id = 10,
                    Name = "Desert Oasis",
                    Details = "Stay in the serene beauty of this desert villa with breathtaking sunset views.",
                    Occupancy = 5,
                    Amenity = "Private Pool, Outdoor Fireplace, Wi-Fi",
                    Sqft = 650,
                    Rate = 320,
                    ImageUrl = "https://desertoasisvillas.com"
                },
                new Villa()
                {
                    Id = 11,
                    Name = "Secluded Jungle Retreat",
                    Details = "Disconnect and relax in this secluded jungle villa surrounded by nature.",
                    Occupancy = 6,
                    Amenity = "Infinity Pool, Outdoor Kitchen, Wi-Fi",
                    Sqft = 750,
                    Rate = 400,
                    ImageUrl = "https://jungleescapevillas.com"
                },
                new Villa()
                {
                    Id = 12,
                    Name = "Cliffside Haven",
                    Details = "Perched on a cliff, this villa offers spectacular ocean views and luxury living.",
                    Occupancy = 5,
                    Amenity = "Private Balcony, Infinity Pool, Wi-Fi",
                    Sqft = 700,
                    Rate = 550,
                    ImageUrl = "https://pixabay.com/photos/cliffside-villa"
                },
                new Villa()
                {
                    Id = 13,
                    Name = "Island Hideaway",
                    Details = "Your own private island getaway with pristine beaches and crystal-clear waters.",
                    Occupancy = 8,
                    Amenity = "Private Beach, Water Sports Gear, Wi-Fi",
                    Sqft = 1000,
                    Rate = 1200,
                    ImageUrl = "https://unsplash.com/photos/island-hideaway"
                },
                new Villa()
                {
                    Id = 14,
                    Name = "Vintage Vineyard Villa",
                    Details = "Stay amidst lush vineyards in this charming villa with a rustic touch.",
                    Occupancy = 4,
                    Amenity = "Wine Cellar, Vineyard Tours, Wi-Fi",
                    Sqft = 500,
                    Rate = 300,
                    ImageUrl = "https://vineyardvillas.com"
                },
                new Villa()
                {
                    Id = 15,
                    Name = "Snowy Chalet",
                    Details = "A cozy and warm chalet perfect for ski trips and winter getaways.",
                    Occupancy = 6,
                    Amenity = "Ski-In/Ski-Out Access, Fireplace, Wi-Fi",
                    Sqft = 600,
                    Rate = 450,
                    ImageUrl = "https://pixabay.com/photos/snowy-chalet"
                },
                new Villa()
                {
                    Id = 16,
                    Name = "Mediterranean Escape",
                    Details = "A sunny villa inspired by Mediterranean architecture and lifestyle.",
                    Occupancy = 5,
                    Amenity = "Terrace, Olive Garden, Wi-Fi",
                    Sqft = 550,
                    Rate = 280,
                    ImageUrl = "https://mediterraneanvillas.com"
                },
                new Villa()
                {
                    Id = 17,
                    Name = "Luxury Yacht Villa",
                    Details = "Enjoy luxury on the water with this unique yacht villa experience.",
                    Occupancy = 2,
                    Amenity = "Ocean View, Onboard Chef, Wi-Fi",
                    Sqft = 300,
                    Rate = 1000,
                    ImageUrl = "https://unsplash.com/photos/yacht-villa"
                },
                new Villa()
                {
                    Id = 18,
                    Name = "Countryside Estate",
                    Details = "A grand estate in the countryside, perfect for large gatherings and events.",
                    Occupancy = 12,
                    Amenity = "Banquet Hall, Swimming Pool, Wi-Fi",
                    Sqft = 2000,
                    Rate = 1500,
                    ImageUrl = "https://pixabay.com/photos/countryside-estate"
                },
                new Villa()
                {
                    Id = 19,
                    Name = "Historic Manor",
                    Details = "Step back in time with this historic villa featuring antique decor and charm.",
                    Occupancy = 8,
                    Amenity = "Antique Furnishings, Garden, Wi-Fi",
                    Sqft = 850,
                    Rate = 600,
                    ImageUrl = "https://historicmanorvillas.com"
                },
                new Villa()
                {
                    Id = 20,
                    Name = "Eco-Friendly Retreat",
                    Details = "A sustainable and eco-friendly villa offering modern comforts in nature.",
                    Occupancy = 4,
                    Amenity = "Solar Power, Organic Garden, Wi-Fi",
                    Sqft = 500,
                    Rate = 220,
                    ImageUrl = "https://ecovillas.com"
                }
            );
            modelBuilder.Entity<VillaNumber>().HasData(

                new VillaNumber { Code = 101, VillaID = 1, SpecialDetails = "Near the lake" },
                new VillaNumber { Code = 102, VillaID = 2, SpecialDetails = "Close to the city center" },
                new VillaNumber { Code = 103, VillaID = 3, SpecialDetails = "Next to the park" },
                new VillaNumber { Code = 104, VillaID = 4, SpecialDetails = "Near the mountains" },
                new VillaNumber { Code = 105, VillaID = 5, SpecialDetails = "Seaside view" },
                new VillaNumber { Code = 106, VillaID = 6, SpecialDetails = "Private forest access" },
                new VillaNumber { Code = 107, VillaID = 7, SpecialDetails = "Adjacent to the golf course" },
                new VillaNumber { Code = 108, VillaID = 8, SpecialDetails = "Near the historic district" },
                new VillaNumber { Code = 109, VillaID = 9, SpecialDetails = "In the vineyard area" },
                new VillaNumber { Code = 110, VillaID = 10, SpecialDetails = "Close to the airport" }
            );
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Villa>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.LastUpdatedDate = DateTime.UtcNow;
            }

            foreach (var entry in ChangeTracker.Entries<VillaNumber>().Where(e => e.State == EntityState.Modified))
            {
                entry.Entity.LastUpdatedDate = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
