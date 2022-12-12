using Api.MasterChefe.Domain.Entidades;
using FluentValidation;

namespace Api.MasterChefe.Aplications.Validacoes
{
    public class ReceitaValidacao : AbstractValidator<Receita>
    {
        public ReceitaValidacao()
        {
            RuleFor(x => !String.IsNullOrEmpty(x.titulo)).Must((titulo) =>
            {
                return titulo;
            }).WithMessage("O campo título é obrigatório");
            RuleFor(x => !String.IsNullOrEmpty(x.descricao)).Must((descricao) =>
            {
                return descricao;
            }).WithMessage("O campo de descrição é obrigatório");

            RuleFor(x => x.ingredientes.Count >= 1).Must((ingredientes) =>
            {
                return ingredientes;
            }).WithMessage("A lista de ingredietes deve conter pelo menos um item");

            RuleFor(x => x.descricao.Length > 1000).Must((descricao) =>
            {
                return descricao;
            }).WithMessage("A descrição da receita não deve conter mais que 1000 caracteres.");
            RuleFor(x => x.modoFazer.Length > 1000).Must((modo) =>
            {
                return modo;
            }).WithMessage("A Descrição não deve conter mais que 5000 caracteres.");
        }
    }
}
