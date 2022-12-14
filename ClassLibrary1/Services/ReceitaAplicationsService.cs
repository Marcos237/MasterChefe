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
        private readonly IIngredientesAplicationsService ingredientesAplicationsService;
        private readonly IValidator<Receita> validacao;
        private readonly IEventoService eventoService;
        private readonly IReceitaRepository receitaRepository;
        public ReceitaAplicationsService(IRepository<Receita> repository, IValidator<Receita> validacao, IEventoService eventoService, IReceitaRepository receitaRepository, IIngredientesAplicationsService ingredientesAplicationsService)
        {
            this.repository = repository;
            this.validacao = validacao;
            this.eventoService = eventoService;
            this.receitaRepository = receitaRepository;
            this.ingredientesAplicationsService = ingredientesAplicationsService;
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
                receita.dataCadastro = DateTime.Now;
                var dados = await repository.Salvar(receita);
            }

            return receita;
        }
        public async Task<Receita> Atualizar(Receita receita)
        {
            var dados = await receitaRepository.BuscarPorId(receita.id);
            dados.titulo = receita.titulo;
            dados.descricao = receita.descricao;
            dados.imagem= receita.imagem;
            dados.dataAtualizacao = DateTime.Now;
            dados.modoFazer = receita.modoFazer;
            await repository.Atualizar(dados);
            return receita;
        }

        public async Task<Receita> BuscarPorId(int id)
        {
            return await receitaRepository.BuscarPorId(id);
        }

        public async Task<List<Receita>> BuscarTodos()
        {
            var dados = await repository.BuscarTodos();
            return dados.Where(x => x.ativo == true).ToList();
        }

        public async Task<Receita> Desativar(int id)
        {
            var receita = await receitaRepository.BuscarPorId(id);
            receita.ativo = false;
            await repository.Atualizar(receita);

            return receita;
        }
    }
}
