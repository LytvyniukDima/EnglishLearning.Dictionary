using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models.Metadata;

namespace EnglishLearning.Dictionary.Domain.Repositories
{
    public interface IWordMetadataRepository
    {
        Task AddAllAsync(IReadOnlyList<WordMetadataModel> words);

        Task<IReadOnlyList<WordMetadataModel>> FindAllAsync(IReadOnlyList<string> words);

        Task<IReadOnlyList<WordMetadataModel>> FindAllByTopicsAsync(IReadOnlyList<string> topics);
        
        Task<IReadOnlyList<string>> GetAllWordsAsync();
        
        Task<IReadOnlyList<WordMetadataModel>> GetAllAsync();
    }
}