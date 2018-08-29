using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class curtido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Personal",
                table: "Bodegatripa");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Bodegatripa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Curtido",
                columns: table => new
                {
                    CurtidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BomboId = table.Column<int>(nullable: false),
                    ClasificacionTripaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    NPieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtido", x => x.CurtidoId);
                    table.ForeignKey(
                        name: "FK_Curtido_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_ClasificacionTripa_ClasificacionTripaId",
                        column: x => x.ClasificacionTripaId,
                        principalTable: "ClasificacionTripa",
                        principalColumn: "ClasificacionTripaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BomboId",
                table: "Curtido",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_ClasificacionTripaId",
                table: "Curtido",
                column: "ClasificacionTripaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_FormulaId",
                table: "Curtido",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_PersonalId",
                table: "Curtido",
                column: "PersonalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtido");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalId",
                table: "Bodegatripa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Personal",
                table: "Bodegatripa",
                nullable: false,
                defaultValue: 0);
        }
    }
}
