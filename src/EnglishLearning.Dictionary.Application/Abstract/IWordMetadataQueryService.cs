using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models.Metadata;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IWordMetadataQueryService
    {
        Task<IReadOnlyList<WordMetadataModel>> GetAsync(WordMetadataQueryModel query);

        Task<IReadOnlyList<WordMetadataModel>> FindByTopicsAsync(IReadOnlyList<string> topics);
    }
}