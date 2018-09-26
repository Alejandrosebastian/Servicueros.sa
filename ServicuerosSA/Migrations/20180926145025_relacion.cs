using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_BodegaId",
                table: "Bodegatripa",
                column: "BodegaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegatripa_Bodega_BodegaId",
                table: "Bodegatripa",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegatripa_Bodega_BodegaId",
                table: "Bodegatripa");

            migrationBuilder.DropIndex(
                name: "IX_Bodegatripa_BodegaId",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "Bodegatripa");
        }
    }
}
