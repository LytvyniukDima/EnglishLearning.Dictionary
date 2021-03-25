using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.DB.Abstract;
using EnglishLearning.Dictionary.DB.Entities;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Repositories;

namespace EnglishLearning.Dictionary.Infrastructure.Repositories
{
    internal class WordListItemRepository : IWordListItemRepository
    {
        private readonly IWordListItemMongoRepository _mongoRepository;

        private readonly IMapper _mapper;
        
        public WordListItemRepository(
            IWordListItemMongoRepository mongoRepository,
            IMapper mapper)
        {
            _mongoRepository = mongoRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId)
        {
            var entities = await _mongoRepository.FindAllAsync(x => x.UserId == userId);

            return _mapper.Map<IReadOnlyList<WordListItemModel>>(entities);
        }

        public async Task AddWordListItemDefinitionAsync(AddWordListDefinitionCommandModel command)
        {
            var wordDefinition = _mapper.Map<WordDefinitionEntity>(command.WordDefinition);
            var entity = await _mongoRepository.FindAsync(x => x.UserId == command.UserId && x.Word == command.Word);
            if (entity == null)
            {
                entity = new WordListItemEntity
                {
                    UserId = command.UserId,
                    Word = command.Word,
                };
            }

            entity.WordDefinitions ??= new List<WordDefinitionEntity>();

            if (!entity.WordDefinitions.Exists(x => x.Definition == command.WordDefinition.Definition))
            {
                entity.WordDefinitions.Add(wordDefinition);

                await _mongoRepository.AddOrUpdateAsync(entity);   
            }
        }

        public async Task<IReadOnlyList<WordListItemModel>> FindAllAsync(Guid userId, IReadOnlyList<string> words)
        {
            var entities = await _mongoRepository.FindAllAsync(x =>
                x.UserId == userId
                && words.Contains(x.Word));

            return _mapper.Map<IReadOnlyList<WordListItemModel>>(entities);
        }

        public async Task<IReadOnlyList<WordListItemModel>> GetNotLearnedAsync(Guid userId)
        {
            var entities = await _mongoRepository.FindAllAsync(x => !x.IsLearned);

            return _mapper.Map<IReadOnlyList<WordListItemModel>>(entities);
        }

        public Task UpdateAllAsync(IReadOnlyList<WordListItemModel> words)
        {
            var entities = _mapper.Map<IReadOnlyList<WordListItemEntity>>(words);

            return _mongoRepository.UpdateAllAsync(entities);
        }
    }
}