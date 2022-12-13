using Api.MasterChefe.Domain.Entidades;

namespace Api.MasterChefe.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarUsuario(string nome, string senha);
    }
}
