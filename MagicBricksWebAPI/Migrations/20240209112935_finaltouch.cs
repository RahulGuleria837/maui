using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicBricksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class finaltouch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_properties_CategoryId",
                table: "properties");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "properties",
                newName: "propertyCategory");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "bookMarks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookMarks_ApplicationUserId",
                table: "bookMarks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bookMarks_AspNetUsers_ApplicationUserId",
                table: "bookMarks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookMarks_AspNetUsers_ApplicationUserId",
                table: "bookMarks");

            migrationBuilder.DropIndex(
                name: "IX_bookMarks_ApplicationUserId",
                table: "bookMarks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "bookMarks");

            migrationBuilder.RenameColumn(
                name: "propertyCategory",
                table: "properties",
                newName: "CategoryId");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propertyCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_properties_CategoryId",
                table: "properties",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_properties_categories_CategoryId",
                table: "properties",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
