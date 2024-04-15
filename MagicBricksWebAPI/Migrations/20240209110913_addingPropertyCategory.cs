using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicBricksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingPropertyCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "properties",
                newName: "CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "PropertyPictures",
                table: "properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_properties_CategoryId",
                table: "properties",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_Category_CategoryId",
                table: "properties",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_Category_CategoryId",
                table: "properties");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_properties_CategoryId",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "PropertyPictures",
                table: "properties");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "properties",
                newName: "Category");
        }
    }
}
