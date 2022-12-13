using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Repository.Interface
{
    public interface IIngredienteRepository
    {
        Task<List<Ingrediente>> BuscarPorId(int id);
    }
}
