using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class relacionContratosFacturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Facturas_idFactura",
                table: "Contratos");

            migrationBuilder.DropIndex(
                name: "IX_Contratos_idFactura",
                table: "Contratos");

            migrationBuilder.DropColumn(
                name: "idFactura",
                table: "Contratos");

            migrationBuilder.CreateTable(
                name: "FacturasContratos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idFactura = table.Column<int>(type: "int", nullable: false),
                    idContrato = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasContratos", x => x.id);
                    table.ForeignKey(
                        name: "FK_FacturasContratos_Contratos_idContrato",
                        column: x => x.idContrato,
                        principalTable: "Contratos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturasContratos_Facturas_idFactura",
                        column: x => x.idFactura,
                        principalTable: "Facturas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasContratos_idContrato",
                table: "FacturasContratos",
                column: "idContrato");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasContratos_idFactura",
                table: "FacturasContratos",
                column: "idFactura");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturasContratos");

            migrationBuilder.AddColumn<int>(
                name: "idFactura",
                table: "Contratos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_idFactura",
                table: "Contratos",
                column: "idFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Facturas_idFactura",
                table: "Contratos",
                column: "idFactura",
                principalTable: "Facturas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
