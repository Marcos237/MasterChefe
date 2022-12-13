using Api.MasterChefe.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.MasterChefe.Repository.Context
{
    public class UsuarioContext
    {
        public void ReceitaContextConfig(ModelBuilder models)
        {
            models.Entity<Usuario>(x =>
            {
                x.ToTable("Receita");
                x.HasKey(c => c.id).HasName("Id");
                x.Property(c => c.id).HasColumnName("id").ValueGeneratedOnAdd();
                x.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(100);
                x.Property(c => c.Senha).HasColumnName("Senha").HasMaxLength(100);
                x.Property(c => c.dataCadastro).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.dataAtualizacao).HasColumnName("DataCadastro").HasColumnType("DateTime");
                x.Property(c => c.ativo).HasColumnName("Ativo").HasColumnType("Bit");
            });
        }
    }
}
