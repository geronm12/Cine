using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Infraestructura.Migrations
{
    public partial class Cuarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion");

            migrationBuilder.DropIndex(
                name: "IX_Funcion_CronogramaId",
                table: "Funcion");

            migrationBuilder.DropColumn(
                name: "CronogramaId",
                table: "Funcion");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Entrada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cronograma_FuncionId",
                table: "Cronograma",
                column: "FuncionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcion_Cronograma",
                table: "Cronograma",
                column: "FuncionId",
                principalTable: "Funcion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcion_Cronograma",
                table: "Cronograma");

            migrationBuilder.DropIndex(
                name: "IX_Cronograma_FuncionId",
                table: "Cronograma");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Entrada");

            migrationBuilder.AddColumn<long>(
                name: "CronogramaId",
                table: "Funcion",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_CronogramaId",
                table: "Funcion",
                column: "CronogramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion",
                column: "CronogramaId",
                principalTable: "Cronograma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
