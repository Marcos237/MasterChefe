using Api.MasterChefe.Aplications.Interfaces;
using Api.MasterChefe.Aplications.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MasterChefe.Ioc.Initializers
{
    public class AplicationInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IReceitasAplicationsService, ReceitaAplicationsService>();
        }
    }
}
