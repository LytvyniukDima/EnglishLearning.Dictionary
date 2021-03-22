using System.Collections.Generic;
using EnglishLearning.Dictionary.Common.Models;

namespace EnglishLearning.Dictionary.Web.Contracts.Metadata
{
    public class WordMetadata
    {
        public string Word { get; set; }
        
        public string GuideWord { get; set; }
        
        public DictionaryEnglishLevel Level { get; set; }
        
        public string POS { get; set; }
        
        public IReadOnlyList<string> Topics { get; set; }
    }
}