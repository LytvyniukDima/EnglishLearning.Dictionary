using System;
using EnglishLearning.Dictionary.ExternalServices.Handlers;
using EnglishLearning.Dictionary.ExternalServices.Http;
using EnglishLearning.Utilities.Identity.DelegationHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnglishLearning.Dictionary.Host.Configuration
{
    public static class HttpClientSettings
    {
        public static IServiceCollection AddEnglishLearningHttp(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var fileManagerAddress = configuration
                .GetValue<Uri>("ExternalServices:FileManager");

            var wordsApiAddress = configuration
                .GetValue<Uri>("WordsApi");
            
            services
                .AddHttpClient<FileManagerHttpClient>(c => 
                {
                    c.BaseAddress = fileManagerAddress;
                })
                .AddHttpMessageHandler<JwtInfoHeaderHandler>();

            services
                .AddHttpClient<WordApiHttpClient>(c =>
                {
                    c.BaseAddress = wordsApiAddress;
                })
                .AddHttpMessageHandler<WordApiTokenHandler>();
            
            return services;
        }
    }
}