using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class otra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "Curtido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BodegaId",
                table: "Curtido",
                column: "BodegaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_Bodega_BodegaId",
                table: "Curtido",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_Bodega_BodegaId",
                table: "Curtido");

            migrationBuilder.DropIndex(
                name: "IX_Curtido_BodegaId",
                table: "Curtido");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "Curtido");
        }
    }
}
