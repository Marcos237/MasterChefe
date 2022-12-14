using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Context
{
    public class UsuarioContext
    {
        public void ReceitaContextConfig(ModelBuilder models)
        {
            models.Entity<Usuario>(x =>
            {
                x.ToTable("Usuarios");
                x.HasKey(c => c.id).HasName("IdUsuario");
                x.Property(c => c.id).ValueGeneratedOnAdd().IsRequired();
                x.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100).IsRequired(); 
                x.Property(c => c.Senha).HasColumnName("Senha").HasMaxLength(100).IsRequired();
                x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.dataAtualizacao).HasColumnName("DataAtualizacao").HasColumnType("DateTime");
                x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");
            });
        }
    }
}
