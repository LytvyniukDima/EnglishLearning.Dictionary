using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Web.Contracts;
using EnglishLearning.Utilities.Identity.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Dictionary.Web.Controllers
{
    [Route("/api/dictionary/list")]
    [ApiController]
    public class WordListItemController : Controller
    {
        private readonly IWordListItemCommandService _commandService;

        private readonly IWordListItemQueryService _queryService;

        private readonly IJwtInfoProvider _jwtInfoProvider;

        private readonly IMapper _mapper;
        
        public WordListItemController(
            IWordListItemCommandService commandService,
            IWordListItemQueryService queryService,
            IJwtInfoProvider jwtInfoProvider,
            IMapper mapper)
        {
            _commandService = commandService;
            _queryService = queryService;
            _jwtInfoProvider = jwtInfoProvider;
            _mapper = mapper;
        }
        
        [EnglishLearningAuthorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWordListDefinitionCommand command)
        {
            var commandModel = _mapper.Map<AddWordListDefinitionCommandModel>(command);
            commandModel.UserId = _jwtInfoProvider.UserId;
            
            await _commandService.AddDefinitionAsync(commandModel);
            
            return Ok();
        }
        
        [EnglishLearningAuthorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = _jwtInfoProvider.UserId;
            var models = await _queryService.FindAllAsync(userId);

            var webModels = _mapper.Map<IReadOnlyList<WordListItem>>(models);
            return Ok(webModels);
        }

        [EnglishLearningAuthorize]
        [HttpPost("learned")]
        public async Task<IActionResult> AddLearnedWords([FromBody] LearnedWordsCommand command)
        {
            var userId = _jwtInfoProvider.UserId;
            var model = _mapper.Map<LearnedWordsCommandModel>(command);
            model.UserId = userId;

            await _commandService.AddLearnedWordsAsync(model);
            
            return Ok();
        }
        
        [EnglishLearningAuthorize]
        [HttpGet("learned/random/{count}")]
        public async Task<IActionResult> GetRandomWordsToLearn([FromRoute] int count)
        {
            var userId = _jwtInfoProvider.UserId;

            var words = await _queryService.GetRandomWordsToLearnAsync(userId, count);
            
            var webModels = _mapper.Map<IReadOnlyList<WordListItem>>(words);
            return Ok(webModels);
        }
    }
}