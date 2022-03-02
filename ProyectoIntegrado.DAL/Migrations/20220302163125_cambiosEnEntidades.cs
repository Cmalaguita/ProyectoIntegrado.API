using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class cambiosEnEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaExpiraSuscripcion",
                table: "Contratos");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Facturas",
                newName: "suscripcionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaPago",
                table: "Facturas",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "idContrato",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idEmpresa",
                table: "Facturas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mensajes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    alumnoId = table.Column<int>(type: "int", nullable: false),
                    empresaId = table.Column<int>(type: "int", nullable: false),
                    contenido = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    leido = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mensajes_Alumnos_alumnoId",
                        column: x => x.alumnoId,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensajes_Empresas_empresaId",
                        column: x => x.empresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idContrato",
                table: "Facturas",
                column: "idContrato");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_idEmpresa",
                table: "Facturas",
                column: "idEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_alumnoId",
                table: "Mensajes",
                column: "alumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajes_empresaId",
                table: "Mensajes",
                column: "empresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Contratos_idContrato",
                table: "Facturas",
                column: "idContrato",
                principalTable: "Contratos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Empresas_idEmpresa",
                table: "Facturas",
                column: "idEmpresa",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Contratos_idContrato",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Empresas_idEmpresa",
                table: "Facturas");

            migrationBuilder.DropTable(
                name: "Mensajes");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_idContrato",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_idEmpresa",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "fechaPago",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "idContrato",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "idEmpresa",
                table: "Facturas");

            migrationBuilder.RenameColumn(
                name: "suscripcionId",
                table: "Facturas",
                newName: "url");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaExpiraSuscripcion",
                table: "Contratos",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
