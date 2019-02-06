using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class webblueee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionesWebblue_Escurrido_EscurridoId",
                table: "ClasificacionesWebblue");

            migrationBuilder.RenameColumn(
                name: "EscurridoId",
                table: "ClasificacionesWebblue",
                newName: "ClasificacionwbId");

            migrationBuilder.RenameIndex(
                name: "IX_ClasificacionesWebblue_EscurridoId",
                table: "ClasificacionesWebblue",
                newName: "IX_ClasificacionesWebblue_ClasificacionwbId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionesWebblue_ClasificacionWB_ClasificacionwbId",
                table: "ClasificacionesWebblue",
                column: "ClasificacionwbId",
                principalTable: "ClasificacionWB",
                principalColumn: "ClasificacionwbId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasificacionesWebblue_ClasificacionWB_ClasificacionwbId",
                table: "ClasificacionesWebblue");

            migrationBuilder.RenameColumn(
                name: "ClasificacionwbId",
                table: "ClasificacionesWebblue",
                newName: "EscurridoId");

            migrationBuilder.RenameIndex(
                name: "IX_ClasificacionesWebblue_ClasificacionwbId",
                table: "ClasificacionesWebblue",
                newName: "IX_ClasificacionesWebblue_EscurridoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClasificacionesWebblue_Escurrido_EscurridoId",
                table: "ClasificacionesWebblue",
                column: "EscurridoId",
                principalTable: "Escurrido",
                principalColumn: "EscurridoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
