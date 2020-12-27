using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryMicroservice.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventorys",
                table: "Inventorys");

            migrationBuilder.RenameTable(
                name: "Inventorys",
                newName: "Inventories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventories",
                table: "Inventories");

            migrationBuilder.RenameTable(
                name: "Inventories",
                newName: "Inventorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventorys",
                table: "Inventorys",
                column: "Id");
        }
    }
}
