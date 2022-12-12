using Api.MasterChefe.Domain.Entidades;
using Api.MasterChefe.Domain.Interface;
using FluentValidation.Results;

namespace Api.MasterChefe.Domain.Service
{
    public class EventoService : IEventoService
    {
        public Eventos Evento { get; set; }
        public EventoService()
        {
           Evento = new Eventos();
        }

        public Task<Eventos> Adicionar(string nome, List<ValidationFailure> menssagens)
        {
            var evento = new Eventos() { Nome = nome};
            foreach (var item in menssagens)
            {
                 Evento.eventos.Add(item.ErrorMessage);
            }

            return Task.FromResult(Evento);
        }
    }
}
