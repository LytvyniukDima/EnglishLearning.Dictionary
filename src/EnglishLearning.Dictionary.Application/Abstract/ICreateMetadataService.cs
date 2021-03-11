using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models.Metadata;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface ICreateMetadataService
    {
        Task CreateWordMetadataAsync(CreateWordMetadataCommandModel createCommand);
    }
}