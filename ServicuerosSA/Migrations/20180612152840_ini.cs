using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Medida_MedidaId",
                table: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_Lote_MedidaId",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "MedidaId",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Lote");

            migrationBuilder.CreateTable(
                name: "ClasificacionTripa",
                columns: table => new
                {
                    ClasificacionTripaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionTripa", x => x.ClasificacionTripaId);
                });

            migrationBuilder.CreateTable(
                name: "Descarne",
                columns: table => new
                {
                    DescarneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    Cantidad = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PelambreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descarne", x => x.DescarneId);
                    table.ForeignKey(
                        name: "FK_Descarne_Pelambre_PelambreId",
                        column: x => x.PelambreId,
                        principalTable: "Pelambre",
                        principalColumn: "PelambreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodegatripa",
                columns: table => new
                {
                    BodegaTripaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClasificacionTripaId = table.Column<int>(nullable: false),
                    DescarneId = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegatripa", x => x.BodegaTripaId);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_ClasificacionTripa_ClasificacionTripaId",
                        column: x => x.ClasificacionTripaId,
                        principalTable: "ClasificacionTripa",
                        principalColumn: "ClasificacionTripaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_Descarne_DescarneId",
                        column: x => x.DescarneId,
                        principalTable: "Descarne",
                        principalColumn: "DescarneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_ClasificacionTripaId",
                table: "Bodegatripa",
                column: "ClasificacionTripaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_DescarneId",
                table: "Bodegatripa",
                column: "DescarneId");

            migrationBuilder.CreateIndex(
                name: "IX_Descarne_PelambreId",
                table: "Descarne",
                column: "PelambreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bodegatripa");

            migrationBuilder.DropTable(
                name: "ClasificacionTripa");

            migrationBuilder.DropTable(
                name: "Descarne");

            migrationBuilder.AddColumn<int>(
                name: "MedidaId",
                table: "Lote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Lote",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Lote_MedidaId",
                table: "Lote",
                column: "MedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Medida_MedidaId",
                table: "Lote",
                column: "MedidaId",
                principalTable: "Medida",
                principalColumn: "MedidaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
