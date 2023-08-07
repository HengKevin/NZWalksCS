using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("162dfa92-4ab8-4e54-ac14-65aa1660e3cc"), "Hard" },
                    { new Guid("c799067b-3855-4749-9f51-b34455ae1a37"), "Easy" },
                    { new Guid("fbcf1091-851d-4ee9-b642-c1429e91c26a"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0c3ba714-3a50-4b93-97b8-c5ece20f5d02"), "STL", "SouthLand", "image.png" },
                    { new Guid("2a5d02f5-cee9-45c0-8ceb-9c0b2fe894d3"), "AKL", "Auckland", "image.png" },
                    { new Guid("814c997d-aacc-4197-93da-4577d2b1e72b"), "WGN", "Wellington", "image.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("162dfa92-4ab8-4e54-ac14-65aa1660e3cc"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c799067b-3855-4749-9f51-b34455ae1a37"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fbcf1091-851d-4ee9-b642-c1429e91c26a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0c3ba714-3a50-4b93-97b8-c5ece20f5d02"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("2a5d02f5-cee9-45c0-8ceb-9c0b2fe894d3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("814c997d-aacc-4197-93da-4577d2b1e72b"));
        }
    }
}
