using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Repository.Interface
{
    public interface IReceitaRepository
    {
        Receita BuscarPorId(int id);
    }
}
