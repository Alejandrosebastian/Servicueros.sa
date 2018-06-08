using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class pelambrecodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Pelambre",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Pelambre",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Pelambre");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Pelambre");
        }
    }
}
