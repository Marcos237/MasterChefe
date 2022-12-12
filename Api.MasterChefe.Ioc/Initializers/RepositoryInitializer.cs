using Api.MasterChefe.Repository.Interface;
using Api.MasterChefe.Repository.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MasterChefe.Ioc.Initializers
{
    public class RepositoryInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
