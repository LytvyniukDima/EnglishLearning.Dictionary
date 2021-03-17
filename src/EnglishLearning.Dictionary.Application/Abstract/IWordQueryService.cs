using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IWordQueryService
    {
        Task<WordDetailsModel> GetWordDetailsAsync(string word);
    }
}