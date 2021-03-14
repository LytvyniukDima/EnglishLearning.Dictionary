using System.Threading.Tasks;
using EnglishLearning.Dictionary.Web.Contracts.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Dictionary.Web
{
    [Route("/api/dictionary/word-analyze")]
    [ApiController]
    public class WordAnalyzeController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> AnalyseWords([FromBody] AnalyseWordCommand analyseCommand)
        {
            return Ok();
        }
    }
}