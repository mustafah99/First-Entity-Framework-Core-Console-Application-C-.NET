using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApplication.Migrations
{
    public partial class DropIDColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Subcategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
