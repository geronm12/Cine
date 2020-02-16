using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Infraestructura.Migrations
{
    public partial class Tercera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion");

            migrationBuilder.AlterColumn<long>(
                name: "CronogramaId",
                table: "Funcion",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "FuncionId",
                table: "Cronograma",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion",
                column: "CronogramaId",
                principalTable: "Cronograma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion");

            migrationBuilder.DropColumn(
                name: "FuncionId",
                table: "Cronograma");

            migrationBuilder.AlterColumn<long>(
                name: "CronogramaId",
                table: "Funcion",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcion_Cronograma_CronogramaId",
                table: "Funcion",
                column: "CronogramaId",
                principalTable: "Cronograma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
