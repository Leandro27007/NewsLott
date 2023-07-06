﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsLott.Datos;

#nullable disable

namespace NewsLott.Migrations
{
    [DbContext(typeof(NewsLottDbContext))]
    [Migration("20230704023230_seedDataEnLoteria-CambioTipoDeDatoEnPkResultadoDeVarCharAInt")]
    partial class seedDataEnLoteriaCambioTipoDeDatoEnPkResultadoDeVarCharAInt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewsLott.Datos.Modelos.Consumidor", b =>
                {
                    b.Property<int>("IdConsumidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsumidor"));

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstadoConsumidor")
                        .HasColumnType("int");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdConsumidor");

                    b.HasIndex("IdEstadoConsumidor");

                    b.ToTable("consumidor");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.EstadoConsumidor", b =>
                {
                    b.Property<int>("IdEstadoConsumidor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoConsumidor"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdEstadoConsumidor");

                    b.ToTable("estadoConsumidor");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.EstadoResultado", b =>
                {
                    b.Property<int>("IdEstadoResultado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoResultado"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdEstadoResultado");

                    b.ToTable("estadoResultado");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.Loteria", b =>
                {
                    b.Property<string>("IdLoteria")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreLoteria")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdLoteria");

                    b.ToTable("loteria");

                    b.HasData(
                        new
                        {
                            IdLoteria = "gana-mas",
                            FechaRegistro = new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6430),
                            NombreLoteria = "Gana Mas"
                        },
                        new
                        {
                            IdLoteria = "loteria-nacional",
                            FechaRegistro = new DateTime(2023, 7, 3, 22, 32, 30, 415, DateTimeKind.Local).AddTicks(6454),
                            NombreLoteria = "Loteria Nacional"
                        });
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.ResultadoQuiniela", b =>
                {
                    b.Property<int>("ResultadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResultadoId"));

                    b.Property<DateTime>("FechaResultado")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEstadoResultado")
                        .HasColumnType("int");

                    b.Property<string>("IdLoteria")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Primera")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Segunda")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Tercera")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ResultadoId");

                    b.HasIndex("IdEstadoResultado");

                    b.HasIndex("IdLoteria");

                    b.ToTable("resultadoQuiniela");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.Consumidor", b =>
                {
                    b.HasOne("NewsLott.Datos.Modelos.EstadoConsumidor", "EstadoConsumidor")
                        .WithMany("Consumidores")
                        .HasForeignKey("IdEstadoConsumidor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConsumidor");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.ResultadoQuiniela", b =>
                {
                    b.HasOne("NewsLott.Datos.Modelos.EstadoResultado", "EstadoResultado")
                        .WithMany("ResultadosQuiniela")
                        .HasForeignKey("IdEstadoResultado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NewsLott.Datos.Modelos.Loteria", "Loteria")
                        .WithMany("ResultadosQuiniela")
                        .HasForeignKey("IdLoteria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoResultado");

                    b.Navigation("Loteria");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.EstadoConsumidor", b =>
                {
                    b.Navigation("Consumidores");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.EstadoResultado", b =>
                {
                    b.Navigation("ResultadosQuiniela");
                });

            modelBuilder.Entity("NewsLott.Datos.Modelos.Loteria", b =>
                {
                    b.Navigation("ResultadosQuiniela");
                });
#pragma warning restore 612, 618
        }
    }
}
