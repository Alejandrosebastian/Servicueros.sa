using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class bodegatripa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "peso",
                table: "ClasificacionTripa");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Descarne",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "NumeroPieles",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Personal",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Bodegatripa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_PersonalId",
                table: "Bodegatripa",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegatripa_Personal_PersonalId",
                table: "Bodegatripa",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "PersonalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegatripa_Personal_PersonalId",
                table: "Bodegatripa");

            migrationBuilder.DropIndex(
                name: "IX_Bodegatripa_PersonalId",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "NumeroPieles",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "Personal",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "Bodegatripa");

            migrationBuilder.AlterColumn<string>(
                name: "Cantidad",
                table: "Descarne",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "ClasificacionTripa",
                nullable: false,
                defaultValue: 0);
        }
    }
}
