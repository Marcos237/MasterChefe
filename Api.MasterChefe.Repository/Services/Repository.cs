using Api.MasterChefe.Repository.Context;
using Api.MasterChefe.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Api.MasterChefe.Repository.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MasterChefeContext masterChefeContext;
        protected DbSet<T> dbSet;

        public Repository(MasterChefeContext masterChefeContext)
        {
            this.masterChefeContext = masterChefeContext;
            dbSet = masterChefeContext.Set<T>();
        }
        public async Task<T> Salvar(T entity)
        {
            var objreturn = dbSet.Add(entity) as T;
            await masterChefeContext.SaveChangesAsync();
            return objreturn;
        }
        public async Task<T> Atualizar(T entity)
        {
            var entry =  masterChefeContext.Entry(entity);
            dbSet.Attach(entity);
            entry.State = EntityState.Modified;
            await masterChefeContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<T>> BuscarTodos()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            var dados = dbSet.Remove(await dbSet.FindAsync(id));
            if (dados != null)
            {
                await masterChefeContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
