using System.IO;
using System.Threading.Tasks;

namespace EnglishLearning.Dictionary.Application.Abstract
{
    public interface IAudioService
    {
        Task<Stream> GetAudioAsync(string str);
    }
}