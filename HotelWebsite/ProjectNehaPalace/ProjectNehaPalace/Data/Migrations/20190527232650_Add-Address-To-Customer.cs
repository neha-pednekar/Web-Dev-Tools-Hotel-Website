using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectNehaPalace.Data.Migrations
{
    public partial class AddAddressToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressID",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressID",
                table: "Customers",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Address_AddressID",
                table: "Customers",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Address_AddressID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");
        }
    }
}
