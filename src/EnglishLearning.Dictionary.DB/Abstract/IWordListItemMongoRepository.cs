using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Utilities.Persistence.Interfaces;

namespace EnglishLearning.Dictionary.DB.Abstract
{
    public interface IWordListItemMongoRepository : IBaseRepository<WordListItemEntity, string>
    {
        Task<WordListItemEntity> AddOrUpdateAsync(WordListItemEntity entity);

        Task UpdateAllAsync(IReadOnlyList<WordListItemEntity> entities);
    }
}