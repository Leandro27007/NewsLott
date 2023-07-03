using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsLott.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracionDefinicionDe5TablasYRelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadoConsumidor",
                columns: table => new
                {
                    IdEstadoConsumidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoConsumidor", x => x.IdEstadoConsumidor);
                });

            migrationBuilder.CreateTable(
                name: "estadoResultado",
                columns: table => new
                {
                    IdEstadoResultado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoResultado", x => x.IdEstadoResultado);
                });

            migrationBuilder.CreateTable(
                name: "loteria",
                columns: table => new
                {
                    IdLoteria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NombreLoteria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loteria", x => x.IdLoteria);
                });

            migrationBuilder.CreateTable(
                name: "consumidor",
                columns: table => new
                {
                    IdConsumidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoConsumidor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumidor", x => x.IdConsumidor);
                    table.ForeignKey(
                        name: "FK_consumidor_estadoConsumidor_IdEstadoConsumidor",
                        column: x => x.IdEstadoConsumidor,
                        principalTable: "estadoConsumidor",
                        principalColumn: "IdEstadoConsumidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "resultadoQuiniela",
                columns: table => new
                {
                    IdResultado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Primera = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Segunda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tercera = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLoteria = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdEstadoResultado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultadoQuiniela", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_resultadoQuiniela_estadoResultado_IdEstadoResultado",
                        column: x => x.IdEstadoResultado,
                        principalTable: "estadoResultado",
                        principalColumn: "IdEstadoResultado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_resultadoQuiniela_loteria_IdLoteria",
                        column: x => x.IdLoteria,
                        principalTable: "loteria",
                        principalColumn: "IdLoteria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_consumidor_IdEstadoConsumidor",
                table: "consumidor",
                column: "IdEstadoConsumidor");

            migrationBuilder.CreateIndex(
                name: "IX_resultadoQuiniela_IdEstadoResultado",
                table: "resultadoQuiniela",
                column: "IdEstadoResultado");

            migrationBuilder.CreateIndex(
                name: "IX_resultadoQuiniela_IdLoteria",
                table: "resultadoQuiniela",
                column: "IdLoteria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "consumidor");

            migrationBuilder.DropTable(
                name: "resultadoQuiniela");

            migrationBuilder.DropTable(
                name: "estadoConsumidor");

            migrationBuilder.DropTable(
                name: "estadoResultado");

            migrationBuilder.DropTable(
                name: "loteria");
        }
    }
}
