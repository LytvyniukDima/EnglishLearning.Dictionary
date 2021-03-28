using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;
using EnglishLearning.Utilities.Http.Extensions;

namespace EnglishLearning.Dictionary.Client
{
    public class WordMetadataClient
    {
        private static readonly Uri BaseUrl = new Uri("api/dictionary/word-metadata", UriKind.Relative);
        private static readonly Uri QueryUrl = new Uri($"{BaseUrl}/query", UriKind.Relative);
        private static readonly Uri FilterQueryUrl = new Uri($"{BaseUrl}/query/filter", UriKind.Relative);
        
        private readonly HttpClient _httpClient;

        public WordMetadataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IReadOnlyList<WordMetadata>> GetWordMetadata(WordMetadataQuery query)
        {
            return _httpClient.PostAsync<WordMetadataQuery, IReadOnlyList<WordMetadata>>(QueryUrl, query);
        }

        public Task<IReadOnlyList<WordMetadata>> FilterAsync(WordMetadataFilterQuery query)
        {
            return _httpClient.PostAsync<WordMetadataFilterQuery, IReadOnlyList<WordMetadata>>(FilterQueryUrl, query);
        }
    }
}