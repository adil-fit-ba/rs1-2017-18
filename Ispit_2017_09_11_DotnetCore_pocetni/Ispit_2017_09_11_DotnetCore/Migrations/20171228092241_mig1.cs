using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Ispit_2017_09_11_DotnetCore.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NastavnikID",
                table: "Odjeljenje",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Nastavnik",
                columns: table => new
                {
                    NastavnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImePrezime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnik", x => x.NastavnikID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odjeljenje_NastavnikID",
                table: "Odjeljenje",
                column: "NastavnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Odjeljenje_Nastavnik_NastavnikID",
                table: "Odjeljenje",
                column: "NastavnikID",
                principalTable: "Nastavnik",
                principalColumn: "NastavnikID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Odjeljenje_Nastavnik_NastavnikID",
                table: "Odjeljenje");

            migrationBuilder.DropTable(
                name: "Nastavnik");

            migrationBuilder.DropIndex(
                name: "IX_Odjeljenje_NastavnikID",
                table: "Odjeljenje");

            migrationBuilder.DropColumn(
                name: "NastavnikID",
                table: "Odjeljenje");
        }
    }
}
