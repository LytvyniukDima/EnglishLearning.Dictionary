using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Dictionary.DB.Abstract
{
    public interface IWordMetadataMongoRepository : IBaseRepository<WordMetadataMongoEntity, string>
    {
    }
}