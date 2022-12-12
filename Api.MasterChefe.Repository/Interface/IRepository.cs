namespace Api.MasterChefe.Repository.Interface
{
    public interface IRepository<T> where T : class 
    {
        T Salvar(T entity);
        T Atualizar(T entity);
        List<T> BuscarTodos();
        bool Desativar(int id);
        bool Deletar(int id);
    }
}
