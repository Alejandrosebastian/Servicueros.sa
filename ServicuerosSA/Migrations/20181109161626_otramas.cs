using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class otramas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_Bodega_BodegaTripaId",
                table: "Curtido");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_Bodegatripa_BodegaTripaId",
                table: "Curtido",
                column: "BodegaTripaId",
                principalTable: "Bodegatripa",
                principalColumn: "BodegaTripaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_Bodegatripa_BodegaTripaId",
                table: "Curtido");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_Bodega_BodegaTripaId",
                table: "Curtido",
                column: "BodegaTripaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
