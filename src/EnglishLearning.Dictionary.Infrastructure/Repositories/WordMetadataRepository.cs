using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
    }
}