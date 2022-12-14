using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Context
{
    public  class IngredienteContext
    {
            public void ReceitaContextConfig(ModelBuilder models)
            {
            models.Entity<Ingrediente>(x =>
            {
                x.ToTable("Ingredientes");
                x.HasKey(c => c.id).HasName("IdIngrediente");
                x.Property(c => c.id).ValueGeneratedOnAdd().IsRequired();
                x.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired();
                x.Property(c => c.receitaId).HasColumnName("ReceitaId").HasMaxLength(100).IsRequired();
                x.Property(c => c.descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(255).IsRequired();
                x.Property(c => c.quantidade).HasColumnName("Quantidade").HasColumnType("int").IsRequired();
                x.Property(c => c.peso).HasColumnName("Peso").HasColumnType("Decimal").HasPrecision(18, 2);
                x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime").IsRequired();
                x.Property(c => c.dataAtualizacao).HasColumnName("DataAtualizacao").HasColumnType("DateTime").IsRequired();
                x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");
            });
        }
    }
}
