using System;
using System.IO;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models.FileManager;
using EnglishLearning.Dictionary.Domain.Repositories;

namespace EnglishLearning.Dictionary.Infrastructure.Repositories
{
    internal class FileRepository : IFileRepository
    {
        public async Task<FileInfoModel> GetFileInfoAsync(Guid fileId)
        {
            return new FileInfoModel();
        }

        public async Task<Stream> GetFileAsync(Guid fileId)
        {
            return new MemoryStream();
        }
    }
}