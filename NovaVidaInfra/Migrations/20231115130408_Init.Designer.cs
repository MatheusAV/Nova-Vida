﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NovaVidaInfra.Common;

#nullable disable

namespace NovaVidaInfra.Migrations
{
    [DbContext(typeof(DbContextApplication))]
    [Migration("20231115130408_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NovaVidaDomain.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("date")
                        .HasColumnName("DataVencimento");

                    b.Property<int>("IdProfessor")
                        .HasColumnType("int")
                        .HasColumnName("IdProfessor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("ValorMensalidade")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorMensalidade");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("NovaVidaDomain.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("date")
                        .HasColumnName("DataContratacao");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Departamento");

                    b.Property<string>("Materia")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Materia");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
