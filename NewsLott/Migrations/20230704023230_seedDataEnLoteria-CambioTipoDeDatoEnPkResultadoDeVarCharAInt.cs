using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsLott.Migrations
{
    /// <inheritdoc />
    public partial class seedDataEnLoteriaCambioTipoDeDatoEnPkResultadoDeVarCharAInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_resultadoQuiniela",
                table: "resultadoQuiniela");

            migrationBuilder.DropColumn(
                name: "IdResultado",
                table: "resultadoQuiniela");

            migrationBuilder.AddColumn<int>(
                name: "ResultadoId",
                table: "resultadoQuiniela",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resultadoQuiniela",
                table: "resultadoQuiniela",
                column: "ResultadoId");

            migrationBuilder.InsertData(
                table: "loteria",
                columns: new[] { "IdLoteria", "FechaRegistro", "NombreLoteria" },
                values: new object[,]
                {
                    { "gana-mas", new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6430), "Gana Mas" },
                    { "loteria-nacional", new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6454), "Loteria Nacional" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_resultadoQuiniela",
                table: "resultadoQuiniela");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "gana-mas");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loteria-nacional");

            migrationBuilder.DropColumn(
                name: "ResultadoId",
                table: "resultadoQuiniela");

            migrationBuilder.AddColumn<string>(
                name: "IdResultado",
                table: "resultadoQuiniela",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_resultadoQuiniela",
                table: "resultadoQuiniela",
                column: "IdResultado");
        }
    }
}
