using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Migrations
{
    public partial class InicijalnaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_gradovi",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__gradovi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_studenti",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GradId = table.Column<int>(nullable: false),
                    ime = table.Column<string>(nullable: true),
                    isDL = table.Column<bool>(nullable: false),
                    password = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    zanimanje = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__studenti", x => x.id);
                    table.ForeignKey(
                        name: "FK__studenti__gradovi_GradId",
                        column: x => x.GradId,
                        principalTable: "_gradovi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__studenti_GradId",
                table: "_studenti",
                column: "GradId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_studenti");

            migrationBuilder.DropTable(
                name: "_gradovi");
        }
    }
}
