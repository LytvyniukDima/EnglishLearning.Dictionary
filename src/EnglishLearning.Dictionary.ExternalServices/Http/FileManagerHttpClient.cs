using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.ExternalServices.Contracts;

namespace EnglishLearning.Dictionary.ExternalServices.Http
{
    public class FileManagerHttpClient
    {
        private static readonly Uri BaseUrl = new Uri("api/file-manager", UriKind.Relative);
        private readonly HttpClient _httpClient;

        public FileManagerHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<FileInfoContract> GetFileInfoAsync(Guid fileId)
        {
            var url = new Uri($"{BaseUrl}/file/{fileId.ToString()}/details", UriKind.Relative);

            return _httpClient.GetAsync<FileInfoContract>(url);
        }
        
        public async Task LoadFileToStreamAsync(Guid fileId, Stream outputStream)
        {
            var url = $"{BaseUrl}/file/{fileId.ToString()}";

            await using var stream = await _httpClient.GetStreamAsync(url);
            await stream.CopyToAsync(outputStream);
        }
    }
}