namespace Api.MasterChefe.Repository.Interface
{
    public interface IRepository<T> where T : class 
    {
        Task<T> Salvar(T entity);
        Task<T> Atualizar(T entity);
        Task<List<T>> BuscarTodos();
        Task<bool> Deletar(int id);
    }
}
