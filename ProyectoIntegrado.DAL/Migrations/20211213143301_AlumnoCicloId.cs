using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class AlumnoCicloId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCiclo",
                table: "Alumnos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_idCiclo",
                table: "Alumnos",
                column: "idCiclo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alumnos_Ciclos_idCiclo",
                table: "Alumnos",
                column: "idCiclo",
                principalTable: "Ciclos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alumnos_Ciclos_idCiclo",
                table: "Alumnos");

            migrationBuilder.DropIndex(
                name: "IX_Alumnos_idCiclo",
                table: "Alumnos");

            migrationBuilder.DropColumn(
                name: "idCiclo",
                table: "Alumnos");
        }
    }
}
