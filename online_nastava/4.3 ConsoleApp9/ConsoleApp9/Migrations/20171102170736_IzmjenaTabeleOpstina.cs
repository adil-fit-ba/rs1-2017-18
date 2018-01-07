using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp9.Migrations
{
    public partial class IzmjenaTabeleOpstina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Naziv",
                table: "Opstina",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Naziv",
                table: "Opstina",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
