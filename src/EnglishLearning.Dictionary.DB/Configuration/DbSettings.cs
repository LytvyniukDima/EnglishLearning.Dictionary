using EnglishLearning.Dictionary.DB.Abstract;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Dictionary.DB.Repositories;
using EnglishLearning.Utilities.Configurations.MongoConfiguration;
using EnglishLearning.Utilities.Persistence.Mongo.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EnglishLearning.Dictionary.DB.Configuration
{
    public static class DbSettings
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // In the future it will be default mode
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3; 
            
            services
                .AddMongoConfiguration(configuration)
                .AddMongoContext(options =>
                {
                    options.HasIndex<WordMetadataEntity>(index =>
                    {
                        index.CreateOne(
                            new CreateIndexModel<WordMetadataEntity>(
                                Builders<WordMetadataEntity>.IndexKeys.Ascending(x => x.Word)));
                    });
                })
                .AddMongoCollectionNamesProvider(x =>
                {
                    x.Add<WordMetadataEntity>("EnglishWordMetadata");
                });
            
            services.AddTransient<IWordMetadataMongoRepository, WordMetadataMongoRepository>();

            return services;
        }
    }
}