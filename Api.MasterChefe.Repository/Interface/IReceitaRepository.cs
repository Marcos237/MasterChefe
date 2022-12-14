using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Repository.Interface
{
    public interface IReceitaRepository
    {
        Task<Receita> BuscarPorId(int id);
    }
}
