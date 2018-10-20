using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class relaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_ClasificacionTripa_ClasificacionTripaId",
                table: "Curtido");

            migrationBuilder.RenameColumn(
                name: "ClasificacionTripaId",
                table: "Curtido",
                newName: "MedidaId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtido_ClasificacionTripaId",
                table: "Curtido",
                newName: "IX_Curtido_MedidaId");

            migrationBuilder.AddColumn<int>(
                name: "BodegaTripaId",
                table: "Curtido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BodegaTripaId",
                table: "Curtido",
                column: "BodegaTripaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_MedidaId",
                table: "Bodegatripa",
                column: "MedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegatripa_Medida_MedidaId",
                table: "Bodegatripa",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_Bodega_BodegaTripaId",
                table: "Curtido",
                column: "BodegaTripaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_Medida_MedidaId",
                table: "Curtido",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegatripa_Medida_MedidaId",
                table: "Bodegatripa");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_Bodega_BodegaTripaId",
                table: "Curtido");

            migrationBuilder.DropForeignKey(
                name: "FK_Curtido_Medida_MedidaId",
                table: "Curtido");

            migrationBuilder.DropIndex(
                name: "IX_Curtido_BodegaTripaId",
                table: "Curtido");

            migrationBuilder.DropIndex(
                name: "IX_Bodegatripa_MedidaId",
                table: "Bodegatripa");

            migrationBuilder.DropColumn(
                name: "BodegaTripaId",
                table: "Curtido");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "Bodegatripa");

            migrationBuilder.RenameColumn(
                name: "MedidaId",
                table: "Curtido",
                newName: "ClasificacionTripaId");

            migrationBuilder.RenameIndex(
                name: "IX_Curtido_MedidaId",
                table: "Curtido",
                newName: "IX_Curtido_ClasificacionTripaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Curtido_ClasificacionTripa_ClasificacionTripaId",
                table: "Curtido",
                column: "ClasificacionTripaId",
                principalTable: "ClasificacionTripa",
                principalColumn: "ClasificacionTripaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
