using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Domain.Models;
using EnglishLearning.Dictionary.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Dictionary.Web.Controllers
{
    [Route("/api/dictionary/word")]
    [ApiController]
    public class WordController : Controller
    {
        private readonly IWordQueryService _queryService;

        private readonly IMapper _mapper;
        
        public WordController(IWordQueryService queryService, IMapper mapper)
        {
            _queryService = queryService;
            _mapper = mapper;
        }
        
        [HttpGet("{word}")]
        public async Task<IActionResult> Get([FromRoute] string word)
        {
            var searchModel = await _queryService.SearchAsync(word);

            var webModel = _mapper.Map<WordSearch>(searchModel);

            return Ok(webModel);
        }
        
        [HttpPost("query")]
        public async Task<IActionResult> FindAll([FromBody] WordSearchQuery query)
        {
            var queryModel = _mapper.Map<WordSearchQueryModel>(query);
            
            var words = await _queryService.FindAllAsync(queryModel);

            var webModels = _mapper.Map<IReadOnlyList<WordDetails>>(words);

            return Ok(webModels);
        }
    }
}