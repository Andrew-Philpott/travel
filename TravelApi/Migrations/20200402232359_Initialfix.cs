using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace travelapi.Migrations
{
    public partial class Initialfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.DestinationId);
                    table.ForeignKey(
                        name: "FK_Destinations_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReviewerName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "DestinationId", "City", "Country", "UserId" },
                values: new object[,]
                {
                    { 1, "Venice", "Italy", null },
                    { 2, "Madrid", "Spain", null },
                    { 3, "Berlin", "Germany", null },
                    { 4, "Lagos", "Nigeria", null },
                    { 5, "Washington", "United States", null },
                    { 6, "Paris", "France", null },
                    { 7, "Paris", "United States", null },
                    { 8, "Berlin", "United States", null },
                    { 9, "Kyiv", "Ukraine", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "DestinationId", "Rating", "ReviewerName", "UserId" },
                values: new object[,]
                {
                    { 1, "Awesome place", 1, 5, "Andriy", null },
                    { 8, "Weather could be better", 1, 4, "Krista", null },
                    { 2, "Better places", 2, 3, "Andriy", null },
                    { 3, "Great except for...", 3, 4, "Andrew", null },
                    { 4, "Awesome place", 3, 4, "Andrew", null },
                    { 5, "Awesome place", 4, 5, "Andriy", null },
                    { 6, "A lot of museums", 5, 4, "Andriy", null },
                    { 7, "City with great history", 5, 5, "Adela", null },
                    { 9, "Nice place to live", 5, 4, "Tiffany", null },
                    { 10, "Missing California", 5, 3, "Steven", null },
                    { 11, "Far from ocean", 5, 2, "Jack", null },
                    { 12, "Best city in Texas", 7, 4, "Jiwon", null },
                    { 13, "Actually we call it New Berlin", 8, 3, "Leilani", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_UserId",
                table: "Destinations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DestinationId",
                table: "Reviews",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}
