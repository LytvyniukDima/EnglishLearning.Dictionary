using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.ExternalServices.Contracts;
using EnglishLearning.Utilities.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace EnglishLearning.Dictionary.ExternalServices.Http
{
    public class WordApiHttpClient
    {
        private static readonly Uri WordsUrl = new Uri("words", UriKind.Relative);
        
        private readonly HttpClient _client;

        private readonly ILogger<WordApiHttpClient> _logger;
        
        public WordApiHttpClient(HttpClient client, ILogger<WordApiHttpClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<WordDetailsContract> GetWordDetailsAsync(string word)
        {
            var url = new Uri($"{WordsUrl}/{word}", UriKind.Relative);

            try
            {
                return await _client.GetAsync<WordDetailsContract>(url);
            }
            catch (HttpRequestException requestException) when (requestException.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Details for word {word} not found.", word);
                return null;
            }
        }
        
        public Task<WordSearchContract> SearchAsync(string pattern, int count)
        {
            var url = new Uri($"{WordsUrl}/?letterPattern={pattern}&limit={count}&page=1", UriKind.Relative);
            
            return _client.GetAsync<WordSearchContract>(url);
        }
    }
}