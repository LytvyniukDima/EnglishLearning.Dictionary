using System;
using System.IO;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Domain.Models.FileManager;

namespace EnglishLearning.Dictionary.Domain.Repositories
{
    public interface IFileRepository
    {
        Task<FileInfoModel> GetFileInfoAsync(Guid fileId);

        Task<Stream> GetFileAsync(Guid fileId);
    }
}