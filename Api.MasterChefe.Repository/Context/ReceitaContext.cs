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
                x.ToTable("Receitas");
                x.HasKey(c => c.id).HasName("IdReceita");
                x.Property(c => c.id).ValueGeneratedOnAdd().IsRequired();
                x.Property(c => c.titulo).HasColumnName("Titulo").HasColumnType("varchar").HasMaxLength(100).IsRequired();
                x.Property(c => c.descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(1000).IsRequired();
                x.Property(c => c.modoFazer).HasColumnName("ModoFazer").HasColumnType("varchar").HasMaxLength(5000).IsRequired();
                x.Property(c => c.imagem).HasColumnName("Imagem").HasMaxLength(250);
                x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.dataAtualizacao).HasColumnName("DataAtualizacao").HasColumnType("DateTime");
                x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");

            });

        }
    }
}
