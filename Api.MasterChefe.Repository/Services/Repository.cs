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
        public T Salvar(T entity)
        {
            var objreturn = dbSet.Add(entity) as T;
            return objreturn;
        }
        public T Atualizar(T entity)
        {
            var entry = masterChefeContext.Entry(entity);
            dbSet.Attach(entity);
            entry.State = EntityState.Modified;

            return entity;
        }

        public T BuscarPorId(int id)
        {
            return dbSet.Find(id);
        }

        public List<T> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public bool Deletar(int id)
        {
            var dados = dbSet.Remove(dbSet.Find(id));
            if (dados != null)
                return true;

            return false;
        }

        public bool Desativar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
