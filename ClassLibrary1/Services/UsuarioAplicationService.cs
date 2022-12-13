using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Repository.Interface;

namespace Api.MasterChefe.Aplications.Services
{
    public class UsuarioAplicationService : IUsuarioAplicationService
    {
        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioAplicationService(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        public Task<Usuario> BuscarUsuario(string nome, string senha)
        {
            return usuarioRepository.BuscarUsuario(nome, senha);    
        }
    }
}
