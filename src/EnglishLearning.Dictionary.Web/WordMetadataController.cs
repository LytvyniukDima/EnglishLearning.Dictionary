using System.Threading.Tasks;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;
using EnglishLearning.Utilities.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EnglishLearning.Dictionary.Web
{
    [Route("/api/dictionary/word-metadata")]
    [ApiController]
    public class WordMetadataController : Controller
    {
        private readonly ILogger<WordMetadataController> _logger;

        public WordMetadataController(ILogger<WordMetadataController> logger)
        {
            _logger = logger;
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWordMetadataCommand createCommand)
        {
            _logger.LogError(createCommand.FileId.ToString());
            return Ok();
        }
    }
}