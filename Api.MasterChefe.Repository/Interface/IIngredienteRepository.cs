using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Repository.Interface
{
    public interface IIngredienteRepository
    {
        List<Ingrediente> BuscarPorId(int id);
    }
}
