using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Domain.Repositories
{
    public interface IWordListItemRepository
    {
        Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId);

        Task AddWordListItemDefinitionAsync(AddWordListDefinitionCommandModel command);

        Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId, IReadOnlyList<string> words);

        Task UpdateAllAsync(IReadOnlyList<WordListItemModel> words);
    }
}