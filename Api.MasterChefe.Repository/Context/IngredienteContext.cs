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
                    x.ToTable("Receita");
                    x.HasKey(c => c.id).HasName("Id");
                    x.Property(c => c.id).HasColumnName("id").ValueGeneratedOnAdd();
                    x.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
                    x.Property(c => c.quantidade).HasColumnName("Quantidade").HasColumnType("int");
                    x.Property(c => c.peso).HasColumnName("Peso").HasColumnType("Decimal");
                    x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime");
                    x.Property(c => c.dataAtualizacao).HasColumnName("DataCadastro").HasColumnType("DateTime");
                    x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");
                });
            }
    }
}
