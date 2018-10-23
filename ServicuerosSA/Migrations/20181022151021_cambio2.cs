using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class cambio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumeroPieles",
                table: "Bodegatripa",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumeroPieles",
                table: "Bodegatripa",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
