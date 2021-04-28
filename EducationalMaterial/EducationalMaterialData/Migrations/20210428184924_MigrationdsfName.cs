using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalMaterialData.Migrations
{
    public partial class MigrationdsfName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 1, "William", "Shakespeare" });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "MaterialTypeId", "Name" },
                values: new object[] { 4, "MVC REST API" });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "MaterialTypeId", "Name" },
                values: new object[] { 5, "EF Core" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "AuthorId", "Description", "MaterialTypeId", "Name", "Url" },
                values: new object[] { 2, 1, ".NET Core 3.1 MVC REST API - Full Course", 4, null, "https://www.youtube.com/watch?v=fmvcAzHpsk8&t=7339s" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "AuthorId", "Description", "MaterialTypeId", "Name", "Url" },
                values: new object[] { 3, 1, "Getting Started with EF Core", 5, null, "https://docs.microsoft.com/en-gb/ef/core/get-started/overview/first-app?tabs=netcore-cli" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "MaterialId" },
                values: new object[] { 6, "Good Material", 2 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "MaterialId" },
                values: new object[] { 7, "Nice One", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "MaterialId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "MaterialTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MaterialTypes",
                keyColumn: "MaterialTypeId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Materials");
        }
    }
}
