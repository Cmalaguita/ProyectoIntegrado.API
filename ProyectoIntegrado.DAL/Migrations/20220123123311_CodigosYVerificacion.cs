using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class CodigosYVerificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoVerificacion",
                table: "Empresas",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailVerificado",
                table: "Empresas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CodigoVerificacion",
                table: "Alumnos",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "EmailVerificado",
                table: "Alumnos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoVerificacion",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EmailVerificado",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CodigoVerificacion",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "EmailVerificado",
                table: "Alumnos");
        }
    }
}
