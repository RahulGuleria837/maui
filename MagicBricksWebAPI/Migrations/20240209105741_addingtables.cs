using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicBricksWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "properties",
                newName: "PropertyPrice");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "properties",
                newName: "PropertyDescription");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PropertyAdvertisementDate",
                table: "properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PropertyArea",
                table: "properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "propertyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Furnishing = table.Column<int>(type: "int", nullable: false),
                    OwnerShipType = table.Column<int>(type: "int", nullable: false),
                    Facing = table.Column<int>(type: "int", nullable: false),
                    MaintenanceCharges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterAvailiability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusElectricity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propertyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_propertyDetails_properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_propertyDetails_PropertyID",
                table: "propertyDetails",
                column: "PropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "propertyDetails");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "PropertyAdvertisementDate",
                table: "properties");

            migrationBuilder.DropColumn(
                name: "PropertyArea",
                table: "properties");

            migrationBuilder.RenameColumn(
                name: "PropertyPrice",
                table: "properties",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "PropertyDescription",
                table: "properties",
                newName: "Area");
        }
    }
}
