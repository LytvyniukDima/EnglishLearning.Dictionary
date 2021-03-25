using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Application.Constants;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class WordMetadataQueryService : IWordMetadataQueryService
    {
        private readonly IWordMetadataRepository _metadataRepository;

        private readonly ILogger<WordMetadataQueryService> _logger;
        
        public WordMetadataQueryService(
            IWordMetadataRepository metadataRepository,
            ILogger<WordMetadataQueryService> logger)
        {
            _metadataRepository = metadataRepository;
            _logger = logger;
        }
        
        public async Task<IReadOnlyList<WordMetadataModel>> GetAsync(WordMetadataQueryModel query)
        {
            var words = query.Words
                .Select(x => MapWordsWithApostrophe(x.ToLower()))
                .ToList();

            var wordsMetadata = await _metadataRepository.FindAllAsync(words);
            var foundedWords = wordsMetadata.Select(x => x.Word);
            var notFoundedWords = words.Except(foundedWords).ToList();
            foreach (var word in notFoundedWords)
            {
                _logger.LogWarning($"Not founded word: {word}");
            }

            return wordsMetadata;
        }

        public Task<IReadOnlyList<WordMetadataModel>> FindByTopicsAsync(IReadOnlyList<string> topics)
        {
            return _metadataRepository.FindAllByTopicsAsync(topics);
        }

        public async Task<IReadOnlyCollection<string>> GetAllTopicsAsync()
        {
            var words = await _metadataRepository.GetAllAsync();
            var topics = words
                .SelectMany(x => x.Topics)
                .ToHashSet();

            return topics;
        }

        private string MapWordsWithApostrophe(string word)
        {
            if (AbbreviationConstants.WordsWithApostropheMap.TryGetValue(word, out string mapped))
            {
                return mapped;
            }

            return word;
        }
    }
}