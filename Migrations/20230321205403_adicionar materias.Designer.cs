﻿// <auto-generated />
using EstudoWeb2.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstudoWeb2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230321205403_adicionar materias")]
    partial class adicionarmaterias
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EstudoWeb2.Models.Anotacao", b =>
                {
                    b.Property<int>("AnotacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnotacaoId"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnotacaoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Anotacoes");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"));

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Materia", b =>
                {
                    b.Property<int>("MateriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MateriaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MateriaId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Questao", b =>
                {
                    b.Property<int>("QuestaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestaoId"));

                    b.Property<string>("Enunciado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Resposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestaoId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Anotacao", b =>
                {
                    b.HasOne("EstudoWeb2.Models.Materia", "Materia")
                        .WithMany("Anotacoes")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Card", b =>
                {
                    b.HasOne("EstudoWeb2.Models.Materia", "Materia")
                        .WithMany("Cards")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Questao", b =>
                {
                    b.HasOne("EstudoWeb2.Models.Materia", "Materia")
                        .WithMany("Questoes")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("EstudoWeb2.Models.Materia", b =>
                {
                    b.Navigation("Anotacoes");

                    b.Navigation("Cards");

                    b.Navigation("Questoes");
                });
#pragma warning restore 612, 618
        }
    }
}
