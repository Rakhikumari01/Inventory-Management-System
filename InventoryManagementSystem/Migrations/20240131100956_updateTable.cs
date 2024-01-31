using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clothing",
                table: "ProductCateogery");

            migrationBuilder.DropColumn(
                name: "Crockery",
                table: "ProductCateogery");

            migrationBuilder.RenameColumn(
                name: "Grocerey",
                table: "ProductCateogery",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCateogery",
                newName: "Grocerey");

            migrationBuilder.AddColumn<string>(
                name: "Clothing",
                table: "ProductCateogery",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Crockery",
                table: "ProductCateogery",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
