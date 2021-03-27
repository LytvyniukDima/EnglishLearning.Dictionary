using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Common.Models;
using EnglishLearning.Dictionary.DB.Abstract;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Domain.Repositories;

namespace EnglishLearning.Dictionary.Infrastructure.Repositories
{
    public class WordMetadataRepository : IWordMetadataRepository
    {
        private readonly IWordMetadataMongoRepository _mongoRepository;

        private readonly IMapper _mapper;

        public WordMetadataRepository(
            IWordMetadataMongoRepository mongoRepository,
            IMapper mapper)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }
        
        public async Task AddAllAsync(IReadOnlyList<WordMetadataModel> words)
        {
            var entities = _mapper.Map<IReadOnlyList<WordMetadataMongoEntity>>(words);

            await _mongoRepository.AddManyAsync(entities);
        }

        public async Task<IReadOnlyList<WordMetadataModel>> FindAllAsync(IReadOnlyList<string> words)
        {
            var entities = await _mongoRepository.FindAllAsync(x => words.Contains(x.Word));

            var models = _mapper.Map<IReadOnlyList<WordMetadataModel>>(entities);

            return models;
        }

        public async Task<IReadOnlyList<WordMetadataModel>> FindAllAsync(string topic, DictionaryEnglishLevel level)
        {
            var entities = await _mongoRepository.FindAllAsync(
                x => x.Level == level && x.Topics.Contains(topic));

            return _mapper.Map<IReadOnlyList<WordMetadataModel>>(entities);
        }

        public async Task<IReadOnlyList<string>> GetAllWordsAsync()
        {
            var entities = await _mongoRepository.GetAllAsync();

            return entities.Select(x => x.Word).ToList();
        }

        public async Task<IReadOnlyList<WordMetadataModel>> GetAllAsync()
        {
            var entities = await _mongoRepository.GetAllAsync();
            var models = _mapper.Map<IReadOnlyList<WordMetadataModel>>(entities);

            return models;
        }
    }
}