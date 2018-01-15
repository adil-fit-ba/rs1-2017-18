using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication2.Migrations
{
    public partial class vjezba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ocjene_studenti_StudentID",
                table: "ocjene");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ocjene",
                table: "ocjene");

            migrationBuilder.RenameTable(
                name: "ocjene",
                newName: "ocjeneStudenata");

            migrationBuilder.RenameIndex(
                name: "IX_ocjene_StudentID",
                table: "ocjeneStudenata",
                newName: "IX_ocjeneStudenata_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ocjeneStudenata",
                table: "ocjeneStudenata",
                column: "OcjeneID");

            migrationBuilder.AddForeignKey(
                name: "FK_ocjeneStudenata_studenti_StudentID",
                table: "ocjeneStudenata",
                column: "StudentID",
                principalTable: "studenti",
                principalColumn: "SudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ocjeneStudenata_studenti_StudentID",
                table: "ocjeneStudenata");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ocjeneStudenata",
                table: "ocjeneStudenata");

            migrationBuilder.RenameTable(
                name: "ocjeneStudenata",
                newName: "ocjene");

            migrationBuilder.RenameIndex(
                name: "IX_ocjeneStudenata_StudentID",
                table: "ocjene",
                newName: "IX_ocjene_StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ocjene",
                table: "ocjene",
                column: "OcjeneID");

            migrationBuilder.AddForeignKey(
                name: "FK_ocjene_studenti_StudentID",
                table: "ocjene",
                column: "StudentID",
                principalTable: "studenti",
                principalColumn: "SudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
