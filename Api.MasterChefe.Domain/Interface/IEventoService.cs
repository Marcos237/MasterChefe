using Api.MasterChefe.Domain.Entidades;
using FluentValidation.Results;

namespace Api.MasterChefe.Domain.Interface
{
    public interface IEventoService
    {
        public Eventos Evento { get; set; }
        Task<Eventos> Adicionar(string nome, List<ValidationFailure> menssagem);
    }
}
