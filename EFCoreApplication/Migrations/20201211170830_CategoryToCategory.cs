using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApplication.Migrations
{
    public partial class CategoryToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesChildCategories",
                columns: table => new
                {
                    ChildCategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesChildCategories", x => new { x.ChildCategoriesCategoryId, x.ParentCategoryCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoriesChildCategories_Category_ParentCategoryCategoryId",
                        column: x => x.ParentCategoryCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesChildCategories_ChildCategories_ChildCategoriesCategoryId",
                        column: x => x.ChildCategoriesCategoryId,
                        principalTable: "ChildCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesChildCategories_ParentCategoryCategoryId",
                table: "CategoriesChildCategories",
                column: "ParentCategoryCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesChildCategories");

            migrationBuilder.DropTable(
                name: "ChildCategories");
        }
    }
}
