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
        private readonly IValidator<Ingrediente> validacao;
        private readonly IEventoService eventoService;
        private readonly IIngredienteRepository ingredienteRepository;

        public IngredienteAplicationService(IRepository<Ingrediente> repository, IValidator<Ingrediente> validacao, IEventoService eventoService, IIngredienteRepository ingredienteRepository)
        {
            this.repository = repository;
            this.validacao = validacao;
            this.eventoService = eventoService;
            this.ingredienteRepository = ingredienteRepository;
        }
        public async Task<Ingrediente> Salvar(Ingrediente ingrediente)
        {
            var validado = await validacao.ValidateAsync(ingrediente);
            if (!validado.IsValid)
            {
                var evento = eventoService.Adicionar("salvar ingrediente", validado.Errors);
            }
            else
            {
                repository.Salvar(ingrediente);
            }

            return ingrediente;
        }
        public async Task<Ingrediente> Atualizar(Ingrediente ingrediente)
        {
            var validado = await validacao.ValidateAsync(ingrediente);
            if (!validado.IsValid)
            {
                var evento = eventoService.Adicionar("salvar ingrediente", validado.Errors);
            }
            else
            {
                repository.Salvar(ingrediente);
            }

            return ingrediente;
        }
        public async Task<List<Ingrediente>> BuscarPorId(int id)
        {
            return await ingredienteRepository.BuscarPorId(id);
        }

        public Task<bool> Deletar(int id)
        {
            var dados = repository.Deletar(id);
            return Task.FromResult(dados);
        }

    }
}
