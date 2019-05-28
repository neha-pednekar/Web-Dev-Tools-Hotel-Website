using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProjectNehaPalace.Data.Migrations
{
    public partial class PopulateCustomerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var random = new Random();
            migrationBuilder.Sql("INSERT INTO Address(AddressID, AddressLine1, AddressLine2, AddressType, City, Country, State, ZipCode) VALUES('" + random.Next(1000, 9999) + "','143 Park Avenue', '', 'HOME', 'Boston', 'US', 'MA', '02215')");
            migrationBuilder.Sql("INSERT INTO Address(AddressID, AddressLine1, AddressLine2, AddressType, City, Country, State, ZipCode) VALUES('" + random.Next(1000, 9999) + "','88 Quarry Avenue', '', 'OFFICE', 'Boston', 'US', 'MA', '02225')");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
