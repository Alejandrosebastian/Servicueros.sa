using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class tipopielclasificaciontripa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPielId",
                table: "Bodega1",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_TipoPielId",
                table: "Bodega1",
                column: "TipoPielId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodega1_TipoPiel_TipoPielId",
                table: "Bodega1",
                column: "TipoPielId",
                principalTable: "TipoPiel",
                principalColumn: "TipoPielId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodega1_TipoPiel_TipoPielId",
                table: "Bodega1");

            migrationBuilder.DropIndex(
                name: "IX_Bodega1_TipoPielId",
                table: "Bodega1");

            migrationBuilder.DropColumn(
                name: "TipoPielId",
                table: "Bodega1");
        }
    }
}
