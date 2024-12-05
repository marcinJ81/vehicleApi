using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType_Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vehicle_Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehicle_Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehicle_SerialNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    Vehicle_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vehicle_StartingMileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleType_id = table.Column<int>(type: "int", nullable: false),
                    Vehicle_Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Vehicle_Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleType_id",
                        column: x => x.VehicleType_id,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleType_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMths",
                columns: table => new
                {
                    Mth_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mth_Register = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    Mth_RegisterDate = table.Column<DateTime>(type: "datetime2(5)", precision: 5, nullable: false),
                    Mth_RegisterInsert = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 12, 2, 22, 42, 6, 281, DateTimeKind.Local).AddTicks(7906)),
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMths", x => x.Mth_Id);
                    table.ForeignKey(
                        name: "FK_VehicleMths_Vehicles_Vehicle_Id",
                        column: x => x.Vehicle_Id,
                        principalTable: "Vehicles",
                        principalColumn: "Vehicle_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMths_Vehicle_Id",
                table: "VehicleMths",
                column: "Vehicle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleType_id",
                table: "Vehicles",
                column: "VehicleType_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleMths");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
