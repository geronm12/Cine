﻿// <auto-generated />
using System;
using Cine.Infraestructura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cine.Infraestructura.Migrations
{
    [DbContext(typeof(Datacontext))]
    [Migration("20200220001028_quinta")]
    partial class quinta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Cine.Cine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Teléfono")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cine");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Cronograma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("DiaId")
                        .HasColumnType("bigint");

                    b.Property<bool>("EsTrasnoche")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("FuncionId")
                        .HasColumnType("bigint");

                    b.Property<long>("HorarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DiaId");

                    b.HasIndex("FuncionId")
                        .IsUnique();

                    b.HasIndex("HorarioId");

                    b.ToTable("Cronograma");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Dia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TipoDia")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Dia");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Entrada.Entrada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Numero")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Entrada");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Funcion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("EntradaId")
                        .HasColumnType("bigint");

                    b.Property<long>("EntradasDisponibles")
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaDeBaja")
                        .HasColumnType("Date");

                    b.Property<DateTime>("FechaDeEstreno")
                        .HasColumnType("Date");

                    b.Property<long>("PeliculaId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric(18,2)");

                    b.Property<long>("SalaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EntradaId")
                        .IsUnique();

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funcion");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Horarios.Horarios", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("DateTime");

                    b.HasKey("Id");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Pelicula.Pelicula", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Descripción")
                        .IsRequired()
                        .HasColumnType("varchar(700) CHARACTER SET utf8mb4")
                        .HasMaxLength(700);

                    b.Property<int>("Duración")
                        .HasColumnType("int");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("Date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("País")
                        .IsRequired()
                        .HasColumnType("varchar(30) CHARACTER SET utf8mb4")
                        .HasMaxLength(30);

                    b.Property<string>("TipoDePelicula")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TrailerURL")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("varchar(300) CHARACTER SET utf8mb4")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Pelicula");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Sala.Sala", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<int>("CapacidadMáx")
                        .HasColumnType("int");

                    b.Property<long>("CineId")
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumeroSalon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Usuario.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Cronograma", b =>
                {
                    b.HasOne("Cine.Dominio._4._1_Entidades.Dia", "Dia")
                        .WithMany("Cronogramas")
                        .HasForeignKey("DiaId")
                        .HasConstraintName("FK_Dia_Cronogramas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Dominio._4._1_Entidades.Funcion", "Funcion")
                        .WithOne("Cronograma")
                        .HasForeignKey("Cine.Dominio._4._1_Entidades.Cronograma", "FuncionId")
                        .HasConstraintName("FK_Funcion_Cronograma")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Dominio._4._1_Entidades.Horarios.Horarios", "Horarios")
                        .WithMany("Cronogramas")
                        .HasForeignKey("HorarioId")
                        .HasConstraintName("FK_Horario_Cronogramas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Funcion", b =>
                {
                    b.HasOne("Cine.Dominio._4._1_Entidades.Entrada.Entrada", "Entrada")
                        .WithOne("Funcion")
                        .HasForeignKey("Cine.Dominio._4._1_Entidades.Funcion", "EntradaId")
                        .HasConstraintName("FK_Funcion_Entrada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Dominio._4._1_Entidades.Pelicula.Pelicula", "Pelicula")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .HasConstraintName("FK_Pelicula_Funciones")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cine.Dominio._4._1_Entidades.Sala.Sala", "Sala")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .HasConstraintName("FK_Sala_Funciones")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cine.Dominio._4._1_Entidades.Sala.Sala", b =>
                {
                    b.HasOne("Cine.Dominio._4._1_Entidades.Cine.Cine", "Cine")
                        .WithMany("Salas")
                        .HasForeignKey("CineId")
                        .HasConstraintName("FK_Salas_Pelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
