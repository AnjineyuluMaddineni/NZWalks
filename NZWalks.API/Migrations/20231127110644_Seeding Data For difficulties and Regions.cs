using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataFordifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("9c8d4d3c-886c-4047-a246-f83679dad41d"), "Easy" },
                    { new Guid("b9669811-b927-4df3-a976-acaa89ecfe1d"), "Hard" },
                    { new Guid("ffad5e27-7741-4630-92de-8b734ddeb037"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("017c7531-0e24-4d4e-841e-1a2f49aeccb2"), "BOP", "Bay Of Plenty", null },
                    { new Guid("ac45ea89-ca96-4dab-b6e4-7d74009e8948"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("d0117d6c-92c3-4cd1-ba6c-6091cfe21662"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("e8fd9c69-ec5a-45bd-88b4-6fc7ca6f0f06"), "STL", "Southland", null },
                    { new Guid("f14e9a4c-c458-4ef1-860e-63c1621f5297"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9c8d4d3c-886c-4047-a246-f83679dad41d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b9669811-b927-4df3-a976-acaa89ecfe1d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ffad5e27-7741-4630-92de-8b734ddeb037"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("017c7531-0e24-4d4e-841e-1a2f49aeccb2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ac45ea89-ca96-4dab-b6e4-7d74009e8948"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d0117d6c-92c3-4cd1-ba6c-6091cfe21662"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e8fd9c69-ec5a-45bd-88b4-6fc7ca6f0f06"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f14e9a4c-c458-4ef1-860e-63c1621f5297"));
        }
    }
}
