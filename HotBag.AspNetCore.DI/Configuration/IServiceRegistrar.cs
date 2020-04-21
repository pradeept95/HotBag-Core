using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.AspNetCore.DI.Configuration
{
    public interface IServiceRegistrar
    { 
        void Update(IServiceCollection serviceCollection);
        void Register(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
