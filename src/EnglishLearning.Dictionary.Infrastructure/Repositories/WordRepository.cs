using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Repositories;
using EnglishLearning.Dictionary.ExternalServices.Http;

namespace EnglishLearning.Dictionary.Infrastructure.Repositories
{
    internal class WordRepository : IWordRepository
    {
        private readonly WordApiHttpClient _client;

        private readonly IMapper _mapper;
        
        public WordRepository(WordApiHttpClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        
        public async Task<WordDetailsModel> GetWordDetailsAsync(string word)
        {
            var details = await _client.GetWordDetailsAsync(word);

            return _mapper.Map<WordDetailsModel>(details);
        }

        public async Task<IReadOnlyList<string>> SearchAsync(string word)
        {
            var pattern = $"^{word}.{{0,25}}$";
            var search = await _client.SearchAsync(pattern, 10);

            return search.Results.Data;
        }
    }
}