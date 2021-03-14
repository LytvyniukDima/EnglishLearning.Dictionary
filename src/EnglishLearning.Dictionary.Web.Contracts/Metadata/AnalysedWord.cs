using EnglishLearning.Dictionary.Common.Models;

namespace EnglishLearning.Dictionary.Web.Contracts.Metadata
{
    public class AnalysedWord
    {
        public string Word { get; set; }

        public DictionaryEnglishLevel Level { get; set; }
        
        public string GuideWord { get; set; }
        
        public string Topic { get; set; }
    }
}