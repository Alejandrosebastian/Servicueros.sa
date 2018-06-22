using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class pelambre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoLote",
                table: "Pelambre",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "Pelambre",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoLote",
                table: "Pelambre");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pelambre");
        }
    }
}
