using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalMaterialData.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "MaterialType",
                columns: table => new
                {
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialType", x => x.MaterialTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Material_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Material_MaterialType_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialType",
                        principalColumn: "MaterialTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[] { 1, "William", "Shakespeare" });

            migrationBuilder.InsertData(
                table: "MaterialType",
                columns: new[] { "MaterialTypeId", "Name" },
                values: new object[] { 4, "MVC REST API" });

            migrationBuilder.InsertData(
                table: "MaterialType",
                columns: new[] { "MaterialTypeId", "Name" },
                values: new object[] { 5, "EF Core" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "AuthorId", "Description", "MaterialTypeId", "Name", "Url" },
                values: new object[] { 2, 1, " Course Rest API", 4, ".NET Core 3.1 MVC REST API - Full Course", "https://www.youtube.com/watch?v=fmvcAzHpsk8&t=7339s" });

            migrationBuilder.InsertData(
                table: "Material",
                columns: new[] { "MaterialId", "AuthorId", "Description", "MaterialTypeId", "Name", "Url" },
                values: new object[] { 3, 1, "EF Core ", 5, "Getting Started with EF Core", "https://docs.microsoft.com/en-gb/ef/core/get-started/overview/first-app?tabs=netcore-cli" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "MaterialId" },
                values: new object[] { 6, "Good Material", 2 });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Description", "MaterialId" },
                values: new object[] { 7, "Nice One", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Material_AuthorId",
                table: "Material",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_MaterialTypeId",
                table: "Material",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaterialId",
                table: "Reviews",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "MaterialType");
        }
    }
}
