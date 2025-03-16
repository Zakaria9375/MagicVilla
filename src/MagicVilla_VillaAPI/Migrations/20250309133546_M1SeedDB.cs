using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class M1SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    VillaID = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Code);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaID",
                        column: x => x.VillaID,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "LastUpdatedDate", "Name", "Occupancy", "Rate", "Sqft" },
                values: new object[,]
                {
                    { 1, "Pool, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7227), "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "https://villascroatia.com/villas/modern-luxury-villa-with-pool-in-medulin", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7229), "Royal Villa", 5, 200.0, 550 },
                    { 2, "Beach Access, BBQ Area, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7238), "Enjoy the ocean breeze in this cozy villa by the beach, perfect for family vacations.", "https://unsplash.com/photos/villa-beachside", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7238), "Beachside Villa", 4, 250.0, 450 },
                    { 3, "Fireplace, Hiking Trails, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7239), "Surrounded by nature, this villa offers stunning mountain views and tranquility.", "https://pixabay.com/photos/mountain-villa-retreat", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7239), "Mountain Retreat", 6, 300.0, 700 },
                    { 4, "City View, Smart Home Features", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7241), "Located in the heart of the city, this modern villa features sleek interiors and convenience.", "https://luxuryurbanvilla.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7241), "Urban Luxe", 3, 400.0, 350 },
                    { 5, "Private Pool, Outdoor Shower, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7242), "Surrounded by lush greenery and exotic plants, this villa is a tropical dream come true.", "https://tropicalvillas.com/paradise", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7242), "Tropical Paradise", 5, 350.0, 600 },
                    { 6, "Garden, Fireplace, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7243), "A rustic villa nestled in the countryside, perfect for a peaceful escape.", "https://pixabay.com/photos/countryside-villa", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7244), "Countryside Charm", 4, 180.0, 500 },
                    { 7, "Lake View, Private Dock, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7245), "Relax by the water in this beautiful lakeside villa, ideal for a romantic getaway.", "https://lakesidevillas.com/haven", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7245), "Lakeside Haven", 2, 275.0, 400 },
                    { 8, "Infinity Pool, Private Elevator, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7246), "Experience ultimate luxury in this spacious penthouse with panoramic city views.", "https://unsplash.com/photos/luxury-penthouse", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7246), "Luxury Penthouse", 4, 500.0, 800 },
                    { 9, "Garden, Patio, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7248), "A charming and quaint cottage surrounded by picturesque gardens.", "https://pixabay.com/photos/cozy-cottage", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7248), "Cozy Cottage", 3, 150.0, 300 },
                    { 10, "Private Pool, Outdoor Fireplace, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7249), "Stay in the serene beauty of this desert villa with breathtaking sunset views.", "https://desertoasisvillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7249), "Desert Oasis", 5, 320.0, 650 },
                    { 11, "Infinity Pool, Outdoor Kitchen, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7250), "Disconnect and relax in this secluded jungle villa surrounded by nature.", "https://jungleescapevillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7251), "Secluded Jungle Retreat", 6, 400.0, 750 },
                    { 12, "Private Balcony, Infinity Pool, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7252), "Perched on a cliff, this villa offers spectacular ocean views and luxury living.", "https://pixabay.com/photos/cliffside-villa", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7252), "Cliffside Haven", 5, 550.0, 700 },
                    { 13, "Private Beach, Water Sports Gear, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7253), "Your own private island getaway with pristine beaches and crystal-clear waters.", "https://unsplash.com/photos/island-hideaway", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7253), "Island Hideaway", 8, 1200.0, 1000 },
                    { 14, "Wine Cellar, Vineyard Tours, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7254), "Stay amidst lush vineyards in this charming villa with a rustic touch.", "https://vineyardvillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7254), "Vintage Vineyard Villa", 4, 300.0, 500 },
                    { 15, "Ski-In/Ski-Out Access, Fireplace, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7256), "A cozy and warm chalet perfect for ski trips and winter getaways.", "https://pixabay.com/photos/snowy-chalet", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7256), "Snowy Chalet", 6, 450.0, 600 },
                    { 16, "Terrace, Olive Garden, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7257), "A sunny villa inspired by Mediterranean architecture and lifestyle.", "https://mediterraneanvillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7257), "Mediterranean Escape", 5, 280.0, 550 },
                    { 17, "Ocean View, Onboard Chef, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7258), "Enjoy luxury on the water with this unique yacht villa experience.", "https://unsplash.com/photos/yacht-villa", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7258), "Luxury Yacht Villa", 2, 1000.0, 300 },
                    { 18, "Banquet Hall, Swimming Pool, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7260), "A grand estate in the countryside, perfect for large gatherings and events.", "https://pixabay.com/photos/countryside-estate", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7260), "Countryside Estate", 12, 1500.0, 2000 },
                    { 19, "Antique Furnishings, Garden, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7261), "Step back in time with this historic villa featuring antique decor and charm.", "https://historicmanorvillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7261), "Historic Manor", 8, 600.0, 850 },
                    { 20, "Solar Power, Organic Garden, Wi-Fi", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7262), "A sustainable and eco-friendly villa offering modern comforts in nature.", "https://ecovillas.com", new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7262), "Eco-Friendly Retreat", 4, 220.0, 500 }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Code", "CreatedDate", "LastUpdatedDate", "SpecialDetails", "VillaID" },
                values: new object[,]
                {
                    { 101, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7359), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7359), "Near the lake", 1 },
                    { 102, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7362), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7363), "Close to the city center", 2 },
                    { 103, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7363), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7363), "Next to the park", 3 },
                    { 104, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7364), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7364), "Near the mountains", 4 },
                    { 105, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7365), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7365), "Seaside view", 5 },
                    { 106, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7366), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7366), "Private forest access", 6 },
                    { 107, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7367), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7367), "Adjacent to the golf course", 7 },
                    { 108, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7367), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7368), "Near the historic district", 8 },
                    { 109, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7368), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7368), "In the vineyard area", 9 },
                    { 110, new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7369), new DateTime(2025, 3, 9, 13, 35, 46, 189, DateTimeKind.Utc).AddTicks(7369), "Close to the airport", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "VillaNumbers",
                column: "VillaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
