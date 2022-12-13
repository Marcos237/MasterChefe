using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Aplications.Interfaces
{
    public interface IUsuarioAplicationService
    {
        Task<Usuario> BuscarUsuario(string nome, string senha);
    }
}
