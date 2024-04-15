using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicBricksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingBookmarkss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_Category_CategoryId",
                table: "properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "categories");

            migrationBuilder.AddColumn<int>(
                name: "propertyCategory",
                table: "categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "bookMarks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookMarks_properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookMarks_PropertyId",
                table: "bookMarks",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties");

            migrationBuilder.DropTable(
                name: "bookMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "propertyCategory",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_Category_CategoryId",
                table: "properties",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
