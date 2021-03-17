using System.Collections.Generic;

namespace EnglishLearning.Dictionary.ExternalServices.Contracts
{
    public class WordDetailsContract
    {
        public string Word { get; set; }
        
        public IReadOnlyList<WordDefinitionContract> Results { get; set; }
    }
}