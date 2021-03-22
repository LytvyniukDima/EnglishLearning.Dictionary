using System.Collections.Generic;
using EnglishLearning.Dictionary.Common.Models;

namespace EnglishLearning.Dictionary.Domain.Models.Metadata
{
    public class WordMetadataModel
    {
        public string Word { get; set; }
        
        public string GuideWord { get; set; }
        
        public DictionaryEnglishLevel Level { get; set; }
        
        public string POS { get; set; }
        
        public List<string> Topics { get; set; }
    }
}