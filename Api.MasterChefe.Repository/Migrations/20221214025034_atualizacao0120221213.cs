using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.MasterChefe.Repository.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao0120221213 : Migration
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
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    ModoFazer = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdReceita", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUsuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Peso = table.Column<decimal>(type: "Decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Ativo = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdIngrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ReceitaId",
                table: "Ingredientes",
                column: "ReceitaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
