﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsLott.DAL;

#nullable disable

namespace NewsLott.DAL.Migrations
{
    [DbContext(typeof(NewsLottDbContext))]
    [Migration("20230817214700_SeedData-AgregarNuevasLoteriasPARTE2")]
    partial class SeedDataAgregarNuevasLoteriasPARTE2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewsLott.Entidades.CompaniaDeLoteria", b =>
                {
                    b.Property<string>("IdCompaniaDeLoteria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreCompania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCompaniaDeLoteria");

                    b.ToTable("companiaDeLoteria");

                    b.HasData(
                        new
                        {
                            IdCompaniaDeLoteria = "nacional",
                            NombreCompania = "Nacional"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "leidsa",
                            NombreCompania = "Leidsa"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "real",
                            NombreCompania = "Real"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "loteka",
                            NombreCompania = "Loteka"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "americanas",
                            NombreCompania = "Americanas"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "la_suerte",
                            NombreCompania = "Primera"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "king_lottery",
                            NombreCompania = "King Lottery"
                        },
                        new
                        {
                            IdCompaniaDeLoteria = "anguila",
                            NombreCompania = "Anguila"
                        });
                });

            modelBuilder.Entity("NewsLott.Entidades.Loteria", b =>
                {
                    b.Property<string>("IdLoteria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCompaniaDeLoteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NombreLoteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdLoteria");

                    b.HasIndex("IdCompaniaDeLoteria");

                    b.ToTable("loteria");

                    b.HasData(
                        new
                        {
                            IdLoteria = "gana_mas",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4113),
                            IdCompaniaDeLoteria = "nacional",
                            NombreLoteria = "Gana Mas"
                        },
                        new
                        {
                            IdLoteria = "loteria_nacional",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4132),
                            IdCompaniaDeLoteria = "nacional",
                            NombreLoteria = "Loteria Nacional"
                        },
                        new
                        {
                            IdLoteria = "juega_+_pega_+",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4134),
                            IdCompaniaDeLoteria = "nacional",
                            NombreLoteria = "Juega + Pega +"
                        },
                        new
                        {
                            IdLoteria = "pega_3_mas",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4135),
                            IdCompaniaDeLoteria = "leidsa",
                            NombreLoteria = "Pega 3 Mas"
                        },
                        new
                        {
                            IdLoteria = "loto_pool",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4136),
                            IdCompaniaDeLoteria = "leidsa",
                            NombreLoteria = "Loto Pool"
                        },
                        new
                        {
                            IdLoteria = "super_kino_tv",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4139),
                            IdCompaniaDeLoteria = "leidsa",
                            NombreLoteria = "Super Kino TV"
                        },
                        new
                        {
                            IdLoteria = "quiniela_leidsa",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4141),
                            IdCompaniaDeLoteria = "leidsa",
                            NombreLoteria = "Quiniela Leidsa"
                        },
                        new
                        {
                            IdLoteria = "loto_loto_mas",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4142),
                            IdCompaniaDeLoteria = "leidsa",
                            NombreLoteria = "Loto Mas"
                        },
                        new
                        {
                            IdLoteria = "quiniela_real",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4143),
                            IdCompaniaDeLoteria = "real",
                            NombreLoteria = "Quiniela Real"
                        },
                        new
                        {
                            IdLoteria = "real_loto_pool",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4145),
                            IdCompaniaDeLoteria = "real",
                            NombreLoteria = "Loto Pool"
                        },
                        new
                        {
                            IdLoteria = "loto_real",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4146),
                            IdCompaniaDeLoteria = "real",
                            NombreLoteria = "Loto Real"
                        },
                        new
                        {
                            IdLoteria = "quiniela_loteka",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4147),
                            IdCompaniaDeLoteria = "loteka",
                            NombreLoteria = "Quiniela Loteka"
                        },
                        new
                        {
                            IdLoteria = "mega_chances",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4149),
                            IdCompaniaDeLoteria = "loteka",
                            NombreLoteria = "Mega Chance"
                        },
                        new
                        {
                            IdLoteria = "new_york_3:30",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4150),
                            IdCompaniaDeLoteria = "americanas",
                            NombreLoteria = "New York 3:30"
                        },
                        new
                        {
                            IdLoteria = "new_york_11:30",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4151),
                            IdCompaniaDeLoteria = "americanas",
                            NombreLoteria = "New York 11:30"
                        },
                        new
                        {
                            IdLoteria = "florida_dia",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4152),
                            IdCompaniaDeLoteria = "americanas",
                            NombreLoteria = "Florida Dia"
                        },
                        new
                        {
                            IdLoteria = "florida_noche",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4153),
                            IdCompaniaDeLoteria = "americanas",
                            NombreLoteria = "Florida Noche"
                        },
                        new
                        {
                            IdLoteria = "la_primera",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4156),
                            IdCompaniaDeLoteria = "primera",
                            NombreLoteria = "La Primera"
                        },
                        new
                        {
                            IdLoteria = "primera_noche",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4157),
                            IdCompaniaDeLoteria = "primera",
                            NombreLoteria = "La Primera Noche"
                        },
                        new
                        {
                            IdLoteria = "loto_5",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4158),
                            IdCompaniaDeLoteria = "primera",
                            NombreLoteria = "Loto 5"
                        },
                        new
                        {
                            IdLoteria = "la_suerte_md",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4159),
                            IdCompaniaDeLoteria = "la_suerte",
                            NombreLoteria = "La Suerte Medio Dia"
                        },
                        new
                        {
                            IdLoteria = "la_suerte_6pm",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4161),
                            IdCompaniaDeLoteria = "la_suerte",
                            NombreLoteria = "La Suerte 6PM"
                        },
                        new
                        {
                            IdLoteria = "quiniela_12:30",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4162),
                            IdCompaniaDeLoteria = "king_lottery",
                            NombreLoteria = "Quiniela 12:13"
                        },
                        new
                        {
                            IdLoteria = "quiniela_7:30",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4163),
                            IdCompaniaDeLoteria = "king_lottery",
                            NombreLoteria = "Quiniela 7:30"
                        },
                        new
                        {
                            IdLoteria = "anguila_10:30_am",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4165),
                            IdCompaniaDeLoteria = "anguila",
                            NombreLoteria = "Anguila 10:30 AM"
                        },
                        new
                        {
                            IdLoteria = "anguila_1:00_pm",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4166),
                            IdCompaniaDeLoteria = "anguila",
                            NombreLoteria = "Anguila 1:00 PM"
                        },
                        new
                        {
                            IdLoteria = "anguila_6:00_pm",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4167),
                            IdCompaniaDeLoteria = "anguila",
                            NombreLoteria = "Anguila 6:00 PM"
                        },
                        new
                        {
                            IdLoteria = "anguila_9:00_pm",
                            FechaRegistro = new DateTime(2023, 8, 17, 17, 47, 0, 571, DateTimeKind.Local).AddTicks(4169),
                            IdCompaniaDeLoteria = "anguila",
                            NombreLoteria = "Anguila 9:00 PM"
                        });
                });

            modelBuilder.Entity("NewsLott.Entidades.ResultadoDeLoteria", b =>
                {
                    b.Property<string>("IdResultadoDeLoteria")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaResultado")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdLoteria")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NumerosPremiados")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdResultadoDeLoteria");

                    b.HasIndex("IdLoteria");

                    b.ToTable("resultadoDeLoteria");
                });

            modelBuilder.Entity("NewsLott.Entidades.Loteria", b =>
                {
                    b.HasOne("NewsLott.Entidades.CompaniaDeLoteria", "CompaniaDeLoteria")
                        .WithMany("Loterias")
                        .HasForeignKey("IdCompaniaDeLoteria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniaDeLoteria");
                });

            modelBuilder.Entity("NewsLott.Entidades.ResultadoDeLoteria", b =>
                {
                    b.HasOne("NewsLott.Entidades.Loteria", "Loteria")
                        .WithMany("ResultadoDeLoterias")
                        .HasForeignKey("IdLoteria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loteria");
                });

            modelBuilder.Entity("NewsLott.Entidades.CompaniaDeLoteria", b =>
                {
                    b.Navigation("Loterias");
                });

            modelBuilder.Entity("NewsLott.Entidades.Loteria", b =>
                {
                    b.Navigation("ResultadoDeLoterias");
                });
#pragma warning restore 612, 618
        }
    }
}
