using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectNehaPalace.Data.Migrations
{
    public partial class UpdateMyApplicationDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Room");

            migrationBuilder.RenameColumn(
                name: "TotalNumberOfRooms",
                table: "Room",
                newName: "TotalNumberOfRoomsAvailable");

            migrationBuilder.RenameColumn(
                name: "RoomsOccupied",
                table: "Room",
                newName: "RoomsSelected");

            migrationBuilder.AddColumn<int>(
                name: "DeluxeOneBedSuite",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeluxeTwoBedSuite",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoubleRoom",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KingSuite",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoyalSuite",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SingleRoom",
                table: "Booking",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeluxeOneBedSuite",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DeluxeTwoBedSuite",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "DoubleRoom",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "KingSuite",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "RoyalSuite",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "SingleRoom",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "TotalNumberOfRoomsAvailable",
                table: "Room",
                newName: "TotalNumberOfRooms");

            migrationBuilder.RenameColumn(
                name: "RoomsSelected",
                table: "Room",
                newName: "RoomsOccupied");

            migrationBuilder.AddColumn<int>(
                name: "Availability",
                table: "Room",
                nullable: false,
                defaultValue: 0);
        }
    }
}
