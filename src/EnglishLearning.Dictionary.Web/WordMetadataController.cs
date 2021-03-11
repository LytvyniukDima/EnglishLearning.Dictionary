using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
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

        private readonly ICreateMetadataService _createMetadataService;

        private readonly IMapper _mapper;
        
        public WordMetadataController(
            ILogger<WordMetadataController> logger,
            ICreateMetadataService createMetadataService,
            IMapper mapper)
        {
            _logger = logger;
            _createMetadataService = createMetadataService;
            _mapper = mapper;
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWordMetadataCommand createCommand)
        {
            _logger.LogError(createCommand.FileId.ToString());

            var createModel = _mapper.Map<CreateWordMetadataCommandModel>(createCommand);
            await _createMetadataService.CreateWordMetadataAsync(createModel);
            
            return Ok();
        }
    }
}