using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IWordQueryService
    {
        Task<WordSearchModel> SearchAsync(string word);
        
        Task<IReadOnlyList<WordDetailsModel>> FindAllAsync(WordSearchQueryModel query);
    }
}