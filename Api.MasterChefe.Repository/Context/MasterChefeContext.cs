using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Context
{
    public class MasterChefeContext : DbContext
    {
        private readonly string conexao;
        public MasterChefeContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conexao);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }


    }
}
