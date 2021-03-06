using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Repositories;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class WordQueryService : IWordQueryService
    {
        private readonly IWordRepository _wordRepository;

        public WordQueryService(IWordRepository wordRepository)
        {
            _wordRepository = wordRepository;
        }
        
        public async Task<WordSearchModel> SearchAsync(string word)
        {
            var details = await _wordRepository.GetWordDetailsAsync(word);
            if (details != null)
            {
                return new WordSearchModel()
                {
                    Word = details,
                    SimilarWords = Array.Empty<string>(),
                };
            }

            var similarWords = await _wordRepository.SearchAsync(word);
            return new WordSearchModel()
            {
                Word = null,
                SimilarWords = similarWords,
            };
        }

        public async Task<IReadOnlyList<WordDetailsModel>> FindAllAsync(WordSearchQueryModel query)
        {
            var wordDetails = await _wordRepository.FindAllAsync(query.Words);

            return wordDetails
                .Where(x => x != null)
                .ToList();
        }
    }
}