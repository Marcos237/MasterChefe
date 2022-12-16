using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Domain.Interface;
using Api.MasterChefe.Repository.Interface;
using FluentValidation;

namespace Api.MasterChefe.Aplications.Services
{
    public class IngredienteAplicationService : IIngredientesAplicationsService
    {
        private readonly IRepository<Ingrediente> repository;
        private readonly IEventoService eventoService;
        private readonly IIngredienteRepository ingredienteRepository;

        public IngredienteAplicationService(IRepository<Ingrediente> repository, IEventoService eventoService, IIngredienteRepository ingredienteRepository)
        {
            this.repository = repository;
            this.eventoService = eventoService;
            this.ingredienteRepository = ingredienteRepository;
        }
        public async Task<Ingrediente> Salvar(Ingrediente ingrediente)
        {
            ingrediente.dataCadastro = DateTime.Now;
            ingrediente.dataAtualizacao = DateTime.Now;
            await repository.Salvar(ingrediente);
            return ingrediente;
        }
        public async Task<Ingrediente> Atualizar(Ingrediente ingrediente)
        {
            var dados = BuscarTodos().Result.FirstOrDefault(x => x.id== ingrediente.id); 
            dados.descricao = ingrediente.descricao;
            dados.Nome = ingrediente.Nome;
            dados.peso= ingrediente.peso;
            dados.quantidade= ingrediente.quantidade;
            dados.dataAtualizacao = ingrediente.dataAtualizacao;

            await repository.Atualizar(dados);
            return dados;
        }
        public async Task<List<Ingrediente>> BuscarPorId(int id)
        {
            return await ingredienteRepository.BuscarPorId(id);
        }

        public async Task<bool> Deletar(int id)
        {
            var dados = await repository.Deletar(id);
            return dados;
        }

        public async Task<List<Ingrediente>> BuscarTodos()
        {
            var dados = await repository.BuscarTodos();
            return dados;
        }
    }
}
