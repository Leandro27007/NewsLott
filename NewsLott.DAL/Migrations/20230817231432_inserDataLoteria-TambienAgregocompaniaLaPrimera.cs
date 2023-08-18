using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsLott.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inserDataLoteriaTambienAgregocompaniaLaPrimera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.UpdateData(
                table: "companiaDeLoteria",
                keyColumn: "IdCompaniaDeLoteria",
                keyValue: "la_suerte",
                column: "NombreCompania",
                value: "La Suerte");

            migrationBuilder.InsertData(
                table: "companiaDeLoteria",
                columns: new[] { "IdCompaniaDeLoteria", "NombreCompania" },
                values: new object[] { "primera", "Primera" });

            migrationBuilder.InsertData(
            table: "loteria",
            columns: new[] { "IdLoteria", "FechaRegistro", "IdCompaniaDeLoteria", "NombreLoteria" },
            values: new object[,]
            {
                    { "la_primera", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5837), "primera", "La Primera" },
                    { "loto_5", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5840), "primera", "Loto 5" },
                    { "loto_real", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5827), "real", "Loto Real" },
                    { "primera_noche", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5838), "primera", "La Primera Noche" },
                    { "quiniela_real", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5824), "real", "Quiniela Real" },
                    { "real_loto_pool", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5826), "real", "Loto Pool" },
                    { "anguila_1:00_pm", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5847), "anguila", "Anguila 1:00 PM" },
                    { "anguila_10:30_am", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5846), "anguila", "Anguila 10:30 AM" },
                    { "anguila_6:00_pm", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5848), "anguila", "Anguila 6:00 PM" },
                    { "anguila_9:00_pm", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5850), "anguila", "Anguila 9:00 PM" },
                    { "florida_dia", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5834), "americanas", "Florida Dia" },
                    { "florida_noche", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5835), "americanas", "Florida Noche" },
                    { "la_suerte_6pm", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5842), "la_suerte", "La Suerte 6PM" },
                    { "la_suerte_md", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5841), "la_suerte", "La Suerte Medio Dia" },
                    { "mega_chances", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5830), "loteka", "Mega Chance" },
                    { "new_york_11:30", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5832), "americanas", "New York 11:30" },
                    { "new_york_3:30", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5831), "americanas", "New York 3:30" },
                    { "quiniela_12:30", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5843), "king_lottery", "Quiniela 12:13" },
                    { "quiniela_7:30", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5845), "king_lottery", "Quiniela 7:30" },
                    { "quiniela_loteka", new DateTime(2023, 8, 17, 17, 43, 31, 781, DateTimeKind.Local).AddTicks(5829), "loteka", "Quiniela Loteka" }
            });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "companiaDeLoteria",
                keyColumn: "IdCompaniaDeLoteria",
                keyValue: "primera");

            migrationBuilder.UpdateData(
                table: "companiaDeLoteria",
                keyColumn: "IdCompaniaDeLoteria",
                keyValue: "la_suerte",
                column: "NombreCompania",
                value: "Primera");

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "anguila_1:00_pm",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5981));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "anguila_10:30_am",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "anguila_6:00_pm",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5982));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "anguila_9:00_pm",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5983));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "florida_dia",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5965));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "florida_noche",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "gana_mas",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "juega_+_pega_+",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "la_primera",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5968));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "la_suerte_6pm",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5974));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "la_suerte_md",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5973));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loteria_nacional",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loto_5",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loto_loto_mas",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5953));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loto_pool",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "loto_real",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5958));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "mega_chances",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5960));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "new_york_11:30",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5964));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "new_york_3:30",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5963));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "pega_3_mas",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "primera_noche",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "quiniela_12:30",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "quiniela_7:30",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5977));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "quiniela_leidsa",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5952));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "quiniela_loteka",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "quiniela_real",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "real_loto_pool",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5957));

            migrationBuilder.UpdateData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "super_kino_tv",
                column: "FechaRegistro",
                value: new DateTime(2023, 8, 17, 18, 56, 8, 704, DateTimeKind.Local).AddTicks(5951));
        }
    }
}
