﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gradeamento_backend.Api.DbContexts;

namespace Api.Migrations
{
    [DbContext(typeof(GradeamentoContext))]
    [Migration("20200722230935_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("gradeamento_backend.Api.Entities.Gradeamento", b =>
                {
                    b.Property<Guid>("IdGradeamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Orientador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Resumo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdGradeamento");

                    b.ToTable("Gradeamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
