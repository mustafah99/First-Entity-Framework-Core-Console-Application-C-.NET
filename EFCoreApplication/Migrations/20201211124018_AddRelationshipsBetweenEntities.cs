using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApplication.Migrations
{
    public partial class AddRelationshipsBetweenEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoriesCategoryId",
                table: "Product",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoriesCategoryId",
                table: "Product",
                column: "CategoriesCategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");
        }
    }
}
