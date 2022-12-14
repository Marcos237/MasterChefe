// <auto-generated />
using System;
using Api.MasterChefe.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api.MasterChefe.Repository.Migrations
{
    [DbContext(typeof(MasterChefeContext))]
    [Migration("20221214025034_atualizacao0120221213")]
    partial class atualizacao0120221213
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.MasterChefe.Domain.Entidades.Ingrediente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<bool>("ativo")
                        .HasColumnType("Bit")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("dataAtualizacao")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Descricao");

                    b.Property<decimal?>("peso")
                        .HasPrecision(18, 2)
                        .HasColumnType("Decimal")
                        .HasColumnName("Peso");

                    b.Property<int?>("quantidade")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<int>("receitaId")
                        .HasMaxLength(100)
                        .HasColumnType("int")
                        .HasColumnName("ReceitaId");

                    b.HasKey("id")
                        .HasName("IdIngrediente");

                    b.HasIndex("receitaId");

                    b.ToTable("Ingredientes", (string)null);
                });

            modelBuilder.Entity("Api.MasterChefe.Domain.Entidades.Receita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("ativo")
                        .HasColumnType("Bit")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("dataAtualizacao")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar")
                        .HasColumnName("Descricao");

                    b.Property<string>("imagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Imagem");

                    b.Property<string>("modoFazer")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("varchar")
                        .HasColumnName("ModoFazer");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Titulo");

                    b.HasKey("id")
                        .HasName("IdReceita");

                    b.ToTable("Receitas", (string)null);
                });

            modelBuilder.Entity("Api.MasterChefe.Domain.Entidades.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Senha");

                    b.Property<bool>("ativo")
                        .HasColumnType("Bit")
                        .HasColumnName("Ativo");

                    b.Property<DateTime>("dataAtualizacao")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("DateTime")
                        .HasColumnName("DataCadastro");

                    b.HasKey("id")
                        .HasName("IdUsuario");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("Api.MasterChefe.Domain.Entidades.Ingrediente", b =>
                {
                    b.HasOne("Api.MasterChefe.Domain.Entidades.Receita", null)
                        .WithMany("ingredientes")
                        .HasForeignKey("receitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Api.MasterChefe.Domain.Entidades.Receita", b =>
                {
                    b.Navigation("ingredientes");
                });
#pragma warning restore 612, 618
        }
    }
}
