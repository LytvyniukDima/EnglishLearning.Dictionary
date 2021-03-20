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
                    options.HasIndex<WordMetadataMongoEntity>(index =>
                    {
                        index.CreateOne(
                            new CreateIndexModel<WordMetadataMongoEntity>(
                                Builders<WordMetadataMongoEntity>.IndexKeys.Ascending(x => x.Word),
                                new CreateIndexOptions() { Unique = true }));
                    });

                    options.HasIndex<WordListItemEntity>(index =>
                    {
                        index.CreateOne(new CreateIndexModel<WordListItemEntity>(
                            Builders<WordListItemEntity>.IndexKeys
                                .Ascending(x => x.UserId)
                                .Ascending(x => x.Word),
                            new CreateIndexOptions() { Unique = true }));
                    });
                })
                .AddMongoCollectionNamesProvider(x =>
                {
                    x.Add<WordMetadataMongoEntity>("EnglishWordMetadata");
                    x.Add<WordListItemEntity>("WordList");
                });
            
            services.AddTransient<IWordMetadataMongoRepository, WordMetadataMongoRepository>();
            services.AddTransient<IWordListItemMongoRepository, WordListItemMongoRepository>();
            
            return services;
        }
    }
}