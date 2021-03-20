using System.Threading.Tasks;
using EnglishLearning.Dictionary.DB.Abstract;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;
using MongoDB.Driver;

namespace EnglishLearning.Dictionary.DB.Repositories
{
    internal class WordListItemMongoRepository : BaseMongoRepository<WordListItemEntity, string>, IWordListItemMongoRepository
    {
        public WordListItemMongoRepository(MongoContext mongoContext)
            : base(mongoContext)
        {
        }

        public async Task<WordListItemEntity> AddOrUpdateAsync(WordListItemEntity entity)
        {
            var filter = new FilterDefinitionBuilder<WordListItemEntity>()
                .Eq(x => x.Id, entity.Id);
            var upsertOptions = new ReplaceOptions { IsUpsert = true };
            
            await _collection.ReplaceOneAsync(filter, entity, upsertOptions);
            return entity;
        }
    }
}