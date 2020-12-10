using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApplication.Migrations
{
    public partial class ReOrderColumnsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubcategoryName",
                table: "Subcategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubcategoryName",
                table: "Subcategory");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Category");
        }
    }
}
