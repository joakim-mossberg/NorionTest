using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleTollApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleOwner",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePassageInvoice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: true),
                    InvoiceDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePassageInvoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleKind = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleOwnerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleOwner_VehicleOwnerId",
                        column: x => x.VehicleOwnerId,
                        principalTable: "VehicleOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePassage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LicensePlateNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PassageDateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    VehiclePassageInvoiceId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePassage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePassage_VehiclePassageInvoice_VehiclePassageInvoiceId",
                        column: x => x.VehiclePassageInvoiceId,
                        principalTable: "VehiclePassageInvoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleOwnerId",
                table: "Vehicle",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePassage_VehiclePassageInvoiceId",
                table: "VehiclePassage",
                column: "VehiclePassageInvoiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehiclePassage");

            migrationBuilder.DropTable(
                name: "VehicleOwner");

            migrationBuilder.DropTable(
                name: "VehiclePassageInvoice");
        }
    }
}
