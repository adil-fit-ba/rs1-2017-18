using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eUniverzitet.Data.Migrations
{
    public partial class AB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId1",
                table: "Zaposleniks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId1",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnickaUloga",
                table: "Korisniks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zaposleniks_KorisnikId1",
                table: "Zaposleniks",
                column: "KorisnikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Students_KorisnikId1",
                table: "Students",
                column: "KorisnikId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Korisniks_KorisnikId1",
                table: "Students",
                column: "KorisnikId1",
                principalTable: "Korisniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaposleniks_Korisniks_KorisnikId1",
                table: "Zaposleniks",
                column: "KorisnikId1",
                principalTable: "Korisniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Korisniks_KorisnikId1",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaposleniks_Korisniks_KorisnikId1",
                table: "Zaposleniks");

            migrationBuilder.DropIndex(
                name: "IX_Zaposleniks_KorisnikId1",
                table: "Zaposleniks");

            migrationBuilder.DropIndex(
                name: "IX_Students_KorisnikId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Zaposleniks");

            migrationBuilder.DropColumn(
                name: "KorisnikId1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "KorisnickaUloga",
                table: "Korisniks");
        }
    }
}
