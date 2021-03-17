using System.Threading.Tasks;
using AutoMapper;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Dictionary.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Dictionary.Web
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
            var details = await _queryService.GetWordDetailsAsync(word);

            var webModel = _mapper.Map<WordDetails>(details);

            return Ok(webModel);
        }
    }
}