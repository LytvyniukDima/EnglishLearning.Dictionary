using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
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
                .Select(x => x.ToLower())
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
    }
}