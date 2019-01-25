using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class escurrudo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurtidoId",
                table: "Escurrido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "Escurrido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodegaId",
                table: "ClasificacionWB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BomboId",
                table: "ClasificacionWB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClasificacionId",
                table: "ClasificacionWB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "ClasificacionWB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalId",
                table: "ClasificacionWB",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_CurtidoId",
                table: "Escurrido",
                column: "CurtidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_PersonalId",
                table: "Escurrido",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_BodegaId",
                table: "ClasificacionWB",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_BomboId",
                table: "ClasificacionWB",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_ClasificacionId",
                table: "ClasificacionWB",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_MedidaId",
                table: "ClasificacionWB",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_PersonalId",
                table: "ClasificacionWB",
                column: "PersonalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionWB_Bodega_BodegaId",
                table: "ClasificacionWB",
                column: "BodegaId",
                principalTable: "Bodega",
                principalColumn: "BodegaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionWB_Bombo_BomboId",
                table: "ClasificacionWB",
                column: "BomboId",
                principalTable: "Bombo",
                principalColumn: "BomboId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionWB_Clasificacion_ClasificacionId",
                table: "ClasificacionWB",
                column: "ClasificacionId",
                principalTable: "Clasificacion",
                principalColumn: "ClasificacionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionWB_Medida_MedidaId",
                table: "ClasificacionWB",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionWB_Personal_PersonalId",
                table: "ClasificacionWB",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "PersonalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Escurrido_Curtido_CurtidoId",
                table: "Escurrido",
                column: "CurtidoId",
                principalTable: "Curtido",
                principalColumn: "CurtidoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Escurrido_Personal_PersonalId",
                table: "Escurrido",
                column: "PersonalId",
                principalTable: "Personal",
                principalColumn: "PersonalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionWB_Bodega_BodegaId",
                table: "ClasificacionWB");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionWB_Bombo_BomboId",
                table: "ClasificacionWB");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionWB_Clasificacion_ClasificacionId",
                table: "ClasificacionWB");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionWB_Medida_MedidaId",
                table: "ClasificacionWB");

            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionWB_Personal_PersonalId",
                table: "ClasificacionWB");

            migrationBuilder.DropForeignKey(
                name: "FK_Escurrido_Curtido_CurtidoId",
                table: "Escurrido");

            migrationBuilder.DropForeignKey(
                name: "FK_Escurrido_Personal_PersonalId",
                table: "Escurrido");

            migrationBuilder.DropIndex(
                name: "IX_Escurrido_CurtidoId",
                table: "Escurrido");

            migrationBuilder.DropIndex(
                name: "IX_Escurrido_PersonalId",
                table: "Escurrido");

            migrationBuilder.DropIndex(
                name: "IX_ClasificacionWB_BodegaId",
                table: "ClasificacionWB");

            migrationBuilder.DropIndex(
                name: "IX_ClasificacionWB_BomboId",
                table: "ClasificacionWB");

            migrationBuilder.DropIndex(
                name: "IX_ClasificacionWB_ClasificacionId",
                table: "ClasificacionWB");

            migrationBuilder.DropIndex(
                name: "IX_ClasificacionWB_MedidaId",
                table: "ClasificacionWB");

            migrationBuilder.DropIndex(
                name: "IX_ClasificacionWB_PersonalId",
                table: "ClasificacionWB");

            migrationBuilder.DropColumn(
                name: "CurtidoId",
                table: "Escurrido");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "Escurrido");

            migrationBuilder.DropColumn(
                name: "BodegaId",
                table: "ClasificacionWB");

            migrationBuilder.DropColumn(
                name: "BomboId",
                table: "ClasificacionWB");

            migrationBuilder.DropColumn(
                name: "ClasificacionId",
                table: "ClasificacionWB");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "ClasificacionWB");

            migrationBuilder.DropColumn(
                name: "PersonalId",
                table: "ClasificacionWB");
        }
    }
}
