using Api.MasterChefe.Domain.Interface;
using Api.MasterChefe.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MasterChefe.Ioc.Initializers
{
    public class DomainInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IEventoService,EventoService>();
        }
    }
}
