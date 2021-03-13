using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class CreateMetadataService : ICreateMetadataService
    {
        private readonly IFileRepository _fileRepository;

        private readonly ILogger<CreateMetadataService> _logger;
        
        public CreateMetadataService(
            IFileRepository fileRepository,
            ILogger<CreateMetadataService> logger)
        {
            _fileRepository = fileRepository;
            _logger = logger;
        }

        public async Task CreateWordMetadataAsync(CreateWordMetadataCommandModel createCommand)
        {
            var fileInfo = await _fileRepository.GetFileInfoAsync(createCommand.FileId);
            
            _logger.LogWarning(fileInfo.Name);
        }
    }
}