using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cine.Infraestructura.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cine",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Dirección = table.Column<string>(maxLength: 150, nullable: false),
                    Teléfono = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dia",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    TipoDia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Numero = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    País = table.Column<string>(maxLength: 30, nullable: false),
                    Duración = table.Column<int>(nullable: false),
                    TipoDePelicula = table.Column<string>(nullable: false),
                    FechaDeCreacion = table.Column<DateTime>(type: "Date", nullable: false),
                    URL = table.Column<string>(maxLength: 300, nullable: false),
                    TrailerURL = table.Column<string>(maxLength: 300, nullable: false),
                    Descripción = table.Column<string>(maxLength: 700, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    TipoUsuario = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    NumeroSalon = table.Column<int>(nullable: false),
                    CapacidadMáx = table.Column<int>(nullable: false),
                    CineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salas_Pelicula",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cronograma",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    DiaId = table.Column<long>(nullable: false),
                    HorarioId = table.Column<long>(nullable: false),
                    EsTrasnoche = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cronograma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dia_Cronogramas",
                        column: x => x.DiaId,
                        principalTable: "Dia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Horario_Cronogramas",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstaBorrado = table.Column<bool>(nullable: false),
                    PeliculaId = table.Column<long>(nullable: false),
                    SalaId = table.Column<long>(nullable: false),
                    EntradaId = table.Column<long>(nullable: false),
                    EntradasDisponibles = table.Column<long>(nullable: false),
                    Precio = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FechaDeEstreno = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaDeBaja = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcion_Entrada",
                        column: x => x.EntradaId,
                        principalTable: "Entrada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pelicula_Funciones",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sala_Funciones",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cronograma_DiaId",
                table: "Cronograma",
                column: "DiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cronograma_HorarioId",
                table: "Cronograma",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_EntradaId",
                table: "Funcion",
                column: "EntradaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_PeliculaId",
                table: "Funcion",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_SalaId",
                table: "Funcion",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_CineId",
                table: "Sala",
                column: "CineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cronograma");

            migrationBuilder.DropTable(
                name: "Funcion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Dia");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Cine");
        }
    }
}
