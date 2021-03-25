using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Dictionary.Application.Configuration
{
    public static class ApplicationSettings
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICreateMetadataService, CreateMetadataService>();
            services.AddTransient<IWordMetadataQueryService, WordMetadataQueryService>();
            services.AddTransient<IWordQueryService, WordQueryService>();
            services.AddTransient<IWordListItemCommandService, WordListItemCommandService>();
            services.AddTransient<IWordListItemQueryService, WordListItemQueryService>();
            services.AddTransient<IAudioService, AudioService>();
            
            return services;
        }
    }
}