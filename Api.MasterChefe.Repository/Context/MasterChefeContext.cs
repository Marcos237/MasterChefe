using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api.MasterChefe.Repository.Context
{
    public class MasterChefeContext : DbContext
    {
        private readonly IConfiguration configuration;
        public MasterChefeContext(DbContextOptions<MasterChefeContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = configuration.GetConnectionString("conexao");
            optionsBuilder.UseSqlServer(conexao);
        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ReceitaContext receita = new ReceitaContext();
            receita.ReceitaContextConfig(modelBuilder);
            IngredienteContext  ingredienteContext = new IngredienteContext();
            ingredienteContext.ReceitaContextConfig(modelBuilder);
            UsuarioContext usuarioContext = new UsuarioContext();
            usuarioContext.ReceitaContextConfig(modelBuilder);
        }
    }
}
