using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Domain.Interface;
using Api.MasterChefe.Repository.Interface;
using FluentValidation;

namespace Api.MasterChefe.Aplications.Services
{
    public class ReceitaAplicationsService : IReceitasAplicationsService
    {
        private readonly IRepository<Receita> repository;
        private readonly IValidator<Receita> validacao;
        private readonly IEventoService eventoService;
        public ReceitaAplicationsService(IRepository<Receita> repository, IValidator<Receita> validacao, IEventoService eventoService)
        {
            this.repository = repository;
            this.validacao = validacao;
            this.eventoService = eventoService;
        }

        public async Task<Receita> Salvar(Receita receita)
        {
            var validado = await validacao.ValidateAsync(receita);
            if (!validado.IsValid)
            {
                var evento = eventoService.Adicionar("salvar receita", validado.Errors);
            }
            else
            {
                repository.Salvar(receita);
            }

            return receita;
        }
        public async Task<Receita> Atualizar(Receita receita)
        {
            var validado = await validacao.ValidateAsync(receita);
            if (!validado.IsValid)
            {
                var evento = eventoService.Adicionar("salvar receita", validado.Errors);
            }
            else
            {
                repository.Atualizar(receita);
            }

            return receita;
        }

        public Task<Receita> BuscarPorId(int id)
        {
            return Task.FromResult(repository.BuscarPorId(id));
        }

        public Task<List<Receita>> BuscarTodos()
        {
            var dados = Task.FromResult(repository.BuscarTodos());
            return dados;
        }

        public Task<Receita> Desativar(Receita receita)
        {
            receita.ativo = false;
            repository.Atualizar(receita);

            return Task.FromResult(receita);
        }
    }
}
