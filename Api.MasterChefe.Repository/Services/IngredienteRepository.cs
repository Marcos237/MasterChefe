using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Repository.Context;
using Api.MasterChefe.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Services
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private readonly MasterChefeContext masterChefeContext;
        protected DbSet<Ingrediente> dbSet;
        public IngredienteRepository(MasterChefeContext masterChefeContext)
        {
            this.masterChefeContext = masterChefeContext;
            dbSet = masterChefeContext.Set<Ingrediente>();

        }
        public async Task<List<Ingrediente>> BuscarPorId(int id)
        {
            var dados = await dbSet.Where(x => x.id == id).ToListAsync();
            return dados;
        }
    }
}
