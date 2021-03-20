using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Domain.Repositories;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class WordListItemCommandService : IWordListItemCommandService
    {
        private readonly IWordListItemRepository _repository;

        public WordListItemCommandService(IWordListItemRepository repository)
        {
            _repository = repository;
        }

        public Task AddDefinitionAsync(AddWordListDefinitionCommandModel command)
        {
            return _repository.AddWordListItemDefinitionAsync(command);
        }
    }
}