using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectNehaPalace.Data.Migrations
{
    public partial class AddTwoNewPropsToPreBookingInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "PreBookingInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEntered",
                table: "PreBookingInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LoggedInUserName",
                table: "PreBookingInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEntered",
                table: "PreBookingInfo");

            migrationBuilder.DropColumn(
                name: "LoggedInUserName",
                table: "PreBookingInfo");

            migrationBuilder.AddColumn<double>(
                name: "NumberOfRooms",
                table: "PreBookingInfo",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
