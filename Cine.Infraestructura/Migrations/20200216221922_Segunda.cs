using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Infraestructura.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CronogramaId",
                table: "Funcion",
                nullable: false,
                defaultValue: 0L);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
