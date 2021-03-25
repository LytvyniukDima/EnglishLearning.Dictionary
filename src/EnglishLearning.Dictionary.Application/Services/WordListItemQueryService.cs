using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Repositories;
using EnglishLearning.Utilities.Linq.Extensions;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class WordListItemQueryService : IWordListItemQueryService
    {
        private readonly IWordListItemRepository _repository;

        public WordListItemQueryService(IWordListItemRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId)
        {
            var items = await _repository.FindAllAsync(userId);
            return items
                .OrderBy(x => x.Word)
                .ToList();
        }

        public async Task<IReadOnlyList<WordListItemModel>> GetRandomWordsToLearnAsync(Guid userId, int count)
        {
            var items = await _repository.GetNotLearnedAsync(userId);

            var randomItems = items
                .GetRandomCountOfElements(count)
                .ToList();

            return randomItems;
        }
    }
}