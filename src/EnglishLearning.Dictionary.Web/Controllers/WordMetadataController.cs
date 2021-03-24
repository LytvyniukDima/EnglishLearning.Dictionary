using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models.Metadata;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;
using EnglishLearning.Utilities.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EnglishLearning.Dictionary.Web.Controllers
{
    [Route("/api/dictionary/word-metadata")]
    [ApiController]
    public class WordMetadataController : Controller
    {
        private readonly ILogger<WordMetadataController> _logger;

        private readonly ICreateMetadataService _createMetadataService;

        private readonly IWordMetadataQueryService _wordMetadataQueryService;
        
        private readonly IMapper _mapper;
        
        public WordMetadataController(
            ILogger<WordMetadataController> logger,
            ICreateMetadataService createMetadataService,
            IWordMetadataQueryService wordMetadataQueryService,
            IMapper mapper)
        {
            _logger = logger;
            _createMetadataService = createMetadataService;
            _wordMetadataQueryService = wordMetadataQueryService;
            _mapper = mapper;
        }
        
        [EnglishLearningAuthorize(AuthorizeRole.Admin)]
        [HttpPost("command")]
        public async Task<IActionResult> Create([FromBody] CreateWordMetadataCommand createCommand)
        {
            var createModel = _mapper.Map<CreateWordMetadataCommandModel>(createCommand);
            await _createMetadataService.CreateWordMetadataAsync(createModel);
            
            return Ok();
        }
        
        [HttpPost("query")]
        public async Task<IActionResult> Get([FromBody] WordMetadataQuery query)
        {
            var queryModel = _mapper.Map<WordMetadataQueryModel>(query);
            var words = await _wordMetadataQueryService.GetAsync(queryModel);

            var webModels = _mapper.Map<IReadOnlyList<WordMetadata>>(words);
            
            return Ok(webModels);
        }
        
        [HttpGet("query/filter")]
        public async Task<IActionResult> Get([FromQuery] string[] topic)
        {
            var words = await _wordMetadataQueryService.FindByTopicsAsync(topic);

            var webModels = _mapper.Map<IReadOnlyList<WordMetadata>>(words);
            
            return Ok(webModels);
        }
    }
}