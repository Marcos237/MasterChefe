using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Aplications.Interfaces
{
    public interface IReceitasAplicationsService
    {
        Task<Receita> Salvar(Receita receita);
        Task<Receita> Atualizar(Receita receita);
        Task<Receita> Desativar(Receita receita);
        Task<Receita> BuscarPorId(int id);
        Task<List<Receita>> BuscarTodos();

    }
}
