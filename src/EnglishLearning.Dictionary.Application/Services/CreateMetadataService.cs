using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models.Metadata;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class CreateMetadataService : ICreateMetadataService
    {
        public async Task CreateWordMetadataAsync(CreateWordMetadataCommandModel createCommand)
        {
        }
    }
}