using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IWordListItemCommandService
    {
        Task AddDefinitionAsync(AddWordListDefinitionCommandModel command);

        Task AddLearnedWordsAsync(LearnedWordsCommandModel command);
    }
}