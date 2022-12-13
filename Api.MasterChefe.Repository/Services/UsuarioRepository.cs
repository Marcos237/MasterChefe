using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Repository.Context;
using Api.MasterChefe.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Services
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MasterChefeContext masterChefeContext;
        protected DbSet<Usuario> dbSet;

        public UsuarioRepository(MasterChefeContext masterChefeContext)
        {
            this.masterChefeContext = masterChefeContext;
            dbSet = masterChefeContext.Set<Usuario>();
        }
        public async Task<Usuario> BuscarUsuario(string nome, string senha)
        {
            return await dbSet.Where(x => x.Nome == nome && x.Senha == senha).FirstOrDefaultAsync() ?? null;
        }
    }
}
