using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Repository.Context;
using Api.MasterChefe.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Api.MasterChefe.Repository.Services
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly MasterChefeContext masterChefeContext;
        protected DbSet<Receita> dbSet;
        protected DbSet<Ingrediente> dbSetIngrediente;

        public ReceitaRepository(MasterChefeContext masterChefeContext)
        {
            this.masterChefeContext = masterChefeContext;
            dbSet = masterChefeContext.Set<Receita>();
            dbSetIngrediente = masterChefeContext.Set<Ingrediente>();
        }

        public async Task<Receita> BuscarPorId(int id)
        {
            var dados = await dbSet.Where(x => x.id == id).FirstOrDefaultAsync();
            if(dados== null) {
                return dados;
            }
            dados.ingredientes = await dbSetIngrediente.Where(x => x.receitaId == id && x.ativo == true).ToListAsync() ?? new List<Ingrediente>();
            return dados;
        }
    }
}
