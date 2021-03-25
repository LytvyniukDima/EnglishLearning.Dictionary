using System.IO;
using System.Threading.Tasks;
using EnglishLearning.Dictionary.Application.Abstract;
using EnglishLearning.Utilities.Speech.Contracts;

namespace EnglishLearning.Dictionary.Application.Services
{
    internal class AudioService : IAudioService
    {
        private readonly ITextToSpeechService _textToSpeechService;

        public AudioService(ITextToSpeechService textToSpeechService)
        {
            _textToSpeechService = textToSpeechService;
        }
        
        public Task<Stream> GetAudioAsync(string str)
        {
            return _textToSpeechService.SpeakTextAsync(str);
        }
    }
}