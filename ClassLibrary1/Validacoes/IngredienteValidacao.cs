using Api.MasterChefe.Domain.Entidades;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Api.MasterChefe.Aplications.Validacoes
{
    public  class IngredienteValidacao : AbstractValidator<Ingrediente>
    {
        public IngredienteValidacao()
        {
            RuleFor(x => !String.IsNullOrEmpty(x.Nome)).Must((titulo) =>
            {
                return titulo;
            }).WithMessage("O campo nome é obrigatório");
        }
    }
}
