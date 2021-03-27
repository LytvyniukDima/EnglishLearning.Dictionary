using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Common.Models;
using EnglishLearning.Dictionary.Domain.Models.Metadata;

namespace EnglishLearning.Dictionary.Domain.Repositories
{
    public interface IWordMetadataRepository
    {
        Task AddAllAsync(IReadOnlyList<WordMetadataModel> words);

        Task<IReadOnlyList<WordMetadataModel>> FindAllAsync(IReadOnlyList<string> words);

        Task<IReadOnlyList<WordMetadataModel>> FindAllAsync(string topic, DictionaryEnglishLevel level);
        
        Task<IReadOnlyList<string>> GetAllWordsAsync();
        
        Task<IReadOnlyList<WordMetadataModel>> GetAllAsync();
    }
}