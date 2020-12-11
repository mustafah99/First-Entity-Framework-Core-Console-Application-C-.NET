using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApplication.Migrations
{
    public partial class OneToManyModelBuilderV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "CategoriesProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesProducts_ProductId",
                table: "CategoriesProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesProducts");

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

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.SubcategoryId);
                });

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
    }
}
