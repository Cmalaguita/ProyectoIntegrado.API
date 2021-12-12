using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace ProyectoIntegrado.DAL.Migrations
{
    public partial class insertarTipoCiclos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sqlFile = @"../ProyectoIntegrado.DAL/Scripts/20211210_Insertar_Tipos_De_Ciclos.sql";
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from tipociclos");
        }
    }
}
