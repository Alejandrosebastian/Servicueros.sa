using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class lotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Lote",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "peso",
                table: "ClasificacionTripa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "ClasificacionTripa");
        }
    }
}
