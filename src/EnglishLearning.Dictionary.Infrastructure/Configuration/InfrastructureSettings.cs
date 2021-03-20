using EnglishLearning.Dictionary.DB.Configuration;
using EnglishLearning.Dictionary.Domain.Repositories;
using EnglishLearning.Dictionary.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Dictionary.Infrastructure.Configuration
{
    public static class InfrastructureSettings
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IWordMetadataRepository, WordMetadataRepository>();
            services.AddTransient<IWordRepository, WordRepository>();
            services.AddTransient<IWordListItemRepository, WordListItemRepository>();
            
            services.AddDbConfiguration(configuration);
            
            return services;
        }
    }
}