using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Domain.Repositories
{
    public interface IWordRepository
    {
        Task<WordDetailsModel> GetWordDetailsAsync(string word);
        
        Task<IReadOnlyList<string>> SearchAsync(string word);
    }
}