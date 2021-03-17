using System.Collections.Generic;

namespace EnglishLearning.Dictionary.Domain.Models
{
    public class WordDefinitionModel
    {
        public string Definition { get; set; }
        
        public string PartOfSpeech { get; set; }
        
        public IReadOnlyList<string> Synonyms { get; set; }
        
        public IReadOnlyList<string> Examples { get; set; }
    }
}