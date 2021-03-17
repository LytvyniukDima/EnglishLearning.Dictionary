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
        
        public Task<WordDetailsModel> GetWordDetailsAsync(string word)
        {
            return _wordRepository.GetWordDetailsAsync(word);
        }
    }
}