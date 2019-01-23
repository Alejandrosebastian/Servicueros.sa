using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class escurrir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClasificacionWB",
                columns: table => new
                {
                    ClasificacionwbId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NumeroPieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionWB", x => x.ClasificacionwbId);
                });

            migrationBuilder.CreateTable(
                name: "Escurrido",
                columns: table => new
                {
                    EscurridoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BomboId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    CodigoLote = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escurrido", x => x.EscurridoId);
                    table.ForeignKey(
                        name: "FK_Escurrido_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_BomboId",
                table: "Escurrido",
                column: "BomboId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClasificacionWB");

            migrationBuilder.DropTable(
                name: "Escurrido");
        }
    }
}
