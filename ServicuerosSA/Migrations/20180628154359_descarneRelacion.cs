using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class descarneRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Descarne",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Descarne_PersonalId",
                table: "Descarne",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descarne_Personal_PersonalId",
                table: "Descarne",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "PersonalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descarne_Personal_PersonalId",
                table: "Descarne");

            migrationBuilder.DropIndex(
                name: "IX_Descarne_PersonalId",
                table: "Descarne");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Descarne");
        }
    }
}
