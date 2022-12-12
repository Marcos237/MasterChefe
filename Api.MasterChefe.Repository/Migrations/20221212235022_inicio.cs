using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.MasterChefe.Repository.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modoFazer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    peso = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    quantidade = table.Column<int>(type: "int", nullable: true),
                    Receitaid = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Receitas_Receitaid",
                        column: x => x.Receitaid,
                        principalTable: "Receitas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_Receitaid",
                table: "Ingredientes",
                column: "Receitaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
