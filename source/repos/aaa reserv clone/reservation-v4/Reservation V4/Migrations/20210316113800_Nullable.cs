using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservation_V4.Migrations
{
    public partial class Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTypes_ReservationTypeId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservStudentViewModel");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationTypeId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTypes_ReservationTypeId",
                table: "Reservations",
                column: "ReservationTypeId",
                principalTable: "ReservationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationTypes_ReservationTypeId",
                table: "Reservations");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationTypeId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ReservStudentViewModel",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    Cause = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    ReservationName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ReservationTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservStudentViewModel", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationTypes_ReservationTypeId",
                table: "Reservations",
                column: "ReservationTypeId",
                principalTable: "ReservationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
