using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.ExternalServices.Constants;
using Microsoft.Extensions.Configuration;

namespace EnglishLearning.Dictionary.ExternalServices.Handlers
{
    public class WordApiTokenHandler : DelegatingHandler
    {
        private readonly IConfiguration _configuration;

        public WordApiTokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var header = _configuration.GetValue<string>(WordApiConstants.WordApiConfigurationKey);
            
            request.Headers.Add(WordApiConstants.WordApiHeaderName, header);
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}