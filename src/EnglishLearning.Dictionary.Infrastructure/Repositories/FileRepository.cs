using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Domain.Models.FileManager;
using EnglishLearning.Dictionary.Domain.Repositories;
using EnglishLearning.Dictionary.ExternalServices.Http;

namespace EnglishLearning.Dictionary.Infrastructure.Repositories
{
    internal class FileRepository : IFileRepository
    {
        private readonly FileManagerHttpClient _client;

        private readonly IMapper _mapper;
        
        public FileRepository(
            FileManagerHttpClient client,
            IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }
        
        public async Task<FileInfoModel> GetFileInfoAsync(Guid fileId)
        {
            var fileInfo = await _client.GetFileInfoAsync(fileId);
            
            return _mapper.Map<FileInfoModel>(fileInfo);
        }

        public async Task<Stream> GetFileAsync(Guid fileId)
        {
            var memoryStream = new MemoryStream();
            await _client.LoadFileToStreamAsync(fileId, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            
            return memoryStream;
        }
    }
}