using EnglishLearning.Dictionary.DB.Abstract;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Utilities.Persistence.Mongo.Contexts;
using EnglishLearning.Utilities.Persistence.Mongo.Repositories;

namespace EnglishLearning.Dictionary.DB.Repositories
{
    internal class WordMetadataMongoRepository : BaseMongoRepository<WordMetadataMongoEntity, string>, IWordMetadataMongoRepository
    {
        public WordMetadataMongoRepository(MongoContext mongoContext)
            : base(mongoContext)
        {
        }
    }
}