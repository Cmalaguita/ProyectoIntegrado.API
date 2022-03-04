using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class fechaFinEnFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaFin",
                table: "Facturas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaFin",
                table: "Facturas");
        }
    }
}
