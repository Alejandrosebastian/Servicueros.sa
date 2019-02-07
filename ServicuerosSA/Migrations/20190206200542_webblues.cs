using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class webblues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasificacionesWebblue",
                columns: table => new
                {
                    clasiwebId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true),
                    EscurridoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionesWebblue", x => x.clasiwebId);
                    table.ForeignKey(
                        name: "FK_ClasificacionesWebblue_Escurrido_EscurridoId",
                        column: x => x.EscurridoId,
                        principalTable: "Escurrido",
                        principalColumn: "EscurridoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionesWebblue_EscurridoId",
                table: "ClasificacionesWebblue",
                column: "EscurridoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasificacionesWebblue");
        }
    }
}
