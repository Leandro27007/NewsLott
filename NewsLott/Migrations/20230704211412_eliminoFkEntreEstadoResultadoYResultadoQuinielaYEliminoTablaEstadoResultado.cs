using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsLott.Migrations
{
    /// <inheritdoc />
    public partial class eliminoFkEntreEstadoResultadoYResultadoQuinielaYEliminoTablaEstadoResultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resultadoQuiniela_estadoResultado_IdEstadoResultado",
                table: "resultadoQuiniela");

            migrationBuilder.DropTable(
                name: "estadoResultado");

            migrationBuilder.DropIndex(
                name: "IX_resultadoQuiniela_IdEstadoResultado",
                table: "resultadoQuiniela");

            migrationBuilder.DropColumn(
                name: "IdEstadoResultado",
                table: "resultadoQuiniela");

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "gana-mas",
                column: "FechaRegistro",
                value: new DateTime(2023, 7, 4, 17, 14, 12, 72, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loteria-nacional",
                column: "FechaRegistro",
                value: new DateTime(2023, 7, 4, 17, 14, 12, 72, DateTimeKind.Local).AddTicks(8287));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstadoResultado",
                table: "resultadoQuiniela",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "gana-mas",
                column: "FechaRegistro",
                value: new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loteria-nacional",
                column: "FechaRegistro",
                value: new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6454));

            migrationBuilder.CreateIndex(
                name: "IX_resultadoQuiniela_IdEstadoResultado",
                table: "resultadoQuiniela",
                column: "IdEstadoResultado");

            migrationBuilder.AddForeignKey(
                name: "FK_resultadoQuiniela_estadoResultado_IdEstadoResultado",
                table: "resultadoQuiniela",
                column: "IdEstadoResultado",
                principalTable: "estadoResultado",
                principalColumn: "IdEstadoResultado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
