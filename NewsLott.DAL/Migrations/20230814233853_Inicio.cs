using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsLott.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companiaDeLoteria",
                columns: table => new
                {
                    IdCompaniaDeLoteria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCompania = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companiaDeLoteria", x => x.IdCompaniaDeLoteria);
                });

            migrationBuilder.CreateTable(
                name: "loteria",
                columns: table => new
                {
                    IdLoteria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreLoteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCompaniaDeLoteria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loteria", x => x.IdLoteria);
                    table.ForeignKey(
                        name: "FK_loteria_companiaDeLoteria_IdCompaniaDeLoteria",
                        column: x => x.IdCompaniaDeLoteria,
                        principalTable: "companiaDeLoteria",
                        principalColumn: "IdCompaniaDeLoteria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resultadoDeLoteria",
                columns: table => new
                {
                    IdResultadoDeLoteria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumerosPremiados = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLoteria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultadoDeLoteria", x => x.IdResultadoDeLoteria);
                    table.ForeignKey(
                        name: "FK_resultadoDeLoteria_loteria_IdLoteria",
                        column: x => x.IdLoteria,
                        principalTable: "loteria",
                        principalColumn: "IdLoteria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "companiaDeLoteria",
                columns: new[] { "IdCompaniaDeLoteria", "NombreCompania" },
                values: new object[,]
                {
                    { "leidsa", "Leidsa" },
                    { "nacional", "Nacional" },
                    { "real", "Real" }
                });

            migrationBuilder.InsertData(
                table: "loteria",
                columns: new[] { "IdLoteria", "FechaRegistro", "IdCompaniaDeLoteria", "NombreLoteria" },
                values: new object[,]
                {
                    { "gana_mas", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8246), "nacional", "Gana Mas" },
                    { "juega_+_pega_+", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8262), "nacional", "Juega + Pega +" },
                    { "loteria_nacional", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8261), "nacional", "Loteria Nacional" },
                    { "loto_loto_mas", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8271), "leidsa", "Loto Mas" },
                    { "loto_pool", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8265), "leidsa", "Loto Pool" },
                    { "pega_3_mas", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8264), "leidsa", "Pega 3 Mas" },
                    { "quiniela_leidsa", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8270), "leidsa", "Quiniela Leidsa" },
                    { "super_kino_tv", new DateTime(2023, 8, 14, 19, 38, 53, 630, DateTimeKind.Local).AddTicks(8268), "leidsa", "Super Kino TV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_loteria_IdCompaniaDeLoteria",
                table: "loteria",
                column: "IdCompaniaDeLoteria");

            migrationBuilder.CreateIndex(
                name: "IX_resultadoDeLoteria_IdLoteria",
                table: "resultadoDeLoteria",
                column: "IdLoteria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resultadoDeLoteria");

            migrationBuilder.DropTable(
                name: "loteria");

            migrationBuilder.DropTable(
                name: "companiaDeLoteria");
        }
    }
}
