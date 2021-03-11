using EnglishLearning.Dictionary.Domain.Repositories;
using EnglishLearning.Dictionary.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Dictionary.Infrastructure.Configuration
{
    public static class InfrastructureSettings
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IFileRepository, FileRepository>();
            
            return services;
        }
    }
}