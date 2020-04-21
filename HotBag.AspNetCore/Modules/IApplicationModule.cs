using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotBag.AspNetCore.Modules
{
    public interface IApplicationModule
    { 
        string ModuleName { get; }
        void PreInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void Initialize(IServiceCollection serviceCollection, IConfiguration configuration);
        void PostInitialize(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
