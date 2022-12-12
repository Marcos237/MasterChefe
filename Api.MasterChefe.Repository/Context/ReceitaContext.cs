using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Context
{
    public class ReceitaContext
    {
        public ReceitaContext() { }

        public void ReceitaContextConfig(ModelBuilder models)
        {
            models.Entity<Receita>(x =>
            {
                x.ToTable("Receita");
                x.HasKey(c => c.id).HasName("Id");
                x.Property(c => c.id).HasColumnName("id").ValueGeneratedOnAdd();
                x.Property(c => c.titulo).HasColumnName("Titulo").HasMaxLength(100);
                x.Property(c => c.descricao).HasColumnName("Descricao").HasMaxLength(1000);
                x.Property(c => c.modoFazer).HasColumnName("ModoFazer").HasMaxLength(5000);
                x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.dataAtualizacao).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");
            });
        }
    }
}
