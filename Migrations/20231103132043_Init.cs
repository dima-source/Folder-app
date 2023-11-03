using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderTestApp.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    CatalogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogs_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "CatalogId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, null, "Creating Digital Images", 1 },
                    { 2, null, "Resources", 1 },
                    { 3, null, "Evidence", 1 },
                    { 4, null, "Graphic product", 1 },
                    { 5, null, "Primary sources", 2 },
                    { 6, null, "Secondary sources", 2 },
                    { 7, null, "Process", 4 },
                    { 8, null, "Final product", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_CatalogId",
                table: "Catalogs",
                column: "CatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
