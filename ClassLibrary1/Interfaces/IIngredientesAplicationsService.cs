using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Aplications.Interfaces
{
    public interface IIngredientesAplicationsService
    {
        Task<Ingrediente> Salvar(Ingrediente ingrediente);
        Task<Ingrediente> Atualizar(Ingrediente ingrediente);
        Task<bool> Deletar(int id);
        Task<List<Ingrediente>> BuscarPorId(int id);
    }
}
