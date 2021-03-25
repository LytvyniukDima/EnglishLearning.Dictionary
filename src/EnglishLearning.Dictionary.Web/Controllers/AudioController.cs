using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace EnglishLearning.Dictionary.Web.Controllers
{
    [Route("/api/dictionary/audio")]
    [ApiController]
    public class AudioController : Controller
    {
        private readonly IAudioService _audioService;

        public AudioController(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        [HttpGet("word/{word}")]
        public async Task<IActionResult> Get([FromRoute] string word)
        {
            var stream = await _audioService.GetAudioAsync(word);

            return new FileStreamResult(stream, "audio/wav")
            {
                FileDownloadName = "audio.wav",
            };
        }
    }
}