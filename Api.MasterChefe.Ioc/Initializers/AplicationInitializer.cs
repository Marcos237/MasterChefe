using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Aplications.Services;
using Api.MasterChefe.Aplications.Validacoes;
using Api.MasterChefe.Domain.Entidades;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MasterChefe.Ioc.Initializers
{
    public class AplicationInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddTransient<IReceitasAplicationsService, ReceitaAplicationsService>();
            services.AddTransient<IIngredientesAplicationsService, IngredienteAplicationService>();
            services.AddTransient<IValidator<Ingrediente>, IngredienteValidacao>();
            services.AddTransient<IValidator<Receita>, ReceitaValidacao>();
            services.AddTransient<IUsuarioAplicationService, UsuarioAplicationService>();
        }
    }
}
